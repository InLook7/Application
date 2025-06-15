using Microsoft.Extensions.Logging;
using Mediator;
using DeskBooking.Application.WorkspaceTypes.Dtos;
using DeskBooking.Domain.Interfaces;
using FluentResults;
using DeskBooking.Application.Common.Errors;

namespace DeskBooking.Application.WorkspaceTypes.Queries.GetList;

public class GetWorkspaceTypeListHandler
    : IRequestHandler<GetWorkspaceTypeListQuery, Result<IEnumerable<WorkspaceTypeListItemDto>>>
{
    private readonly ILogger<GetWorkspaceTypeListHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkspaceTypeListHandler(
        ILogger<GetWorkspaceTypeListHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<IEnumerable<WorkspaceTypeListItemDto>>> Handle(GetWorkspaceTypeListQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting workspace type list.");

        var coworking = await _unitOfWork.CoworkingRepository.GetByIdAsync(query.Id);
        if (coworking == null)
        {
            _logger.LogWarning("Coworking with ID {CoworkingId} does not exist.", query.Id);
            return Result.Fail(new NotFoundError());
        }

        var workspaceTypes = await _unitOfWork.WorkspaceTypeRepository.GetAllWithDetailsAsync();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var workspaceTypeListItemDtos = new List<WorkspaceTypeListItemDto>();

        foreach (var workspaceType in workspaceTypes)
        {
            var capacityGroups = workspaceType.Workspaces
                .Where(w => w.CoworkingId == query.Id)
                .Select(w =>
                {
                    var bookedCount = w.Bookings.Count(b => b.StartDate <= date && b.EndDate >= date);
                    var availableQuantity = Math.Max(0, w.Quantity - bookedCount);

                    return new { w.Capacity, availableQuantity };
                })
                .Where(x => x.availableQuantity > 0)
                .GroupBy(x => x.Capacity)
                .Select(g => new CapacityQuantityGroup(g.Key, g.Sum(x => x.availableQuantity)))
                .ToList();

            var photoPaths = workspaceType.WorkspacePhotos.Select(wp => wp.FilePath).ToList();
            var amenityPaths = workspaceType.WorkspaceTypeAmenities.Select(wta => wta.Amenity.FilePath).ToList();

            workspaceTypeListItemDtos.Add(new WorkspaceTypeListItemDto(
                workspaceType.Id,
                workspaceType.Name,
                workspaceType.Description,
                photoPaths,
                amenityPaths,
                capacityGroups
            ));
        }

        _logger.LogInformation("Successfully fetched {WorkspaceTypeCount} workspace type list items.", workspaceTypeListItemDtos.Count());

        return workspaceTypeListItemDtos;
    }
}