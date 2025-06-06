using Microsoft.Extensions.Logging;
using Mediator;
using DeskBooking.Application.WorkspaceTypes.Dtos;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.WorkspaceTypes.Queries.GetList;

public class GetWorkspaceTypeListHandler
    : IRequestHandler<GetWorkspaceTypeListQuery, IEnumerable<WorkspaceTypeListItemDto>>
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

    public async ValueTask<IEnumerable<WorkspaceTypeListItemDto>> Handle(GetWorkspaceTypeListQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting workspace type list.");

        var workspaceTypes = await _unitOfWork.WorkspaceTypeRepository.GetAllWithDetailsAsync();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var workspaceTypeListItemDtos = workspaceTypes.Select(workspaceType =>
        {
            var capacityGroups = workspaceType.Workspaces
                .Select(workspace =>
                {
                    var bookedCount = workspace.Bookings.Count(b => b.StartDate <= date && b.EndDate >= date);
                    var availableQuantity = Math.Max(0, workspace.Quantity - bookedCount);

                    return new { workspace.Capacity, availableQuantity };
                })
                .Where(x => x.availableQuantity > 0)
                .GroupBy(x => x.Capacity)
                .Select(g => new CapacityQuantityGroup(g.Key, g.Sum(x => x.availableQuantity)))
                .ToList();

            return new WorkspaceTypeListItemDto(
                workspaceType.Id,
                workspaceType.Name,
                workspaceType.Description,
                workspaceType.Photos.Select(p => p.FilePath).ToList(),
                workspaceType.WorkspaceTypeAmenities.Select(wta => wta.Amenity.FilePath).ToList(),
                capacityGroups
            );
        });

        _logger.LogInformation("Successfully fetched {WorkspaceTypeCount} workspace type list items.", workspaceTypeListItemDtos.Count());

        return workspaceTypeListItemDtos;
    }
}