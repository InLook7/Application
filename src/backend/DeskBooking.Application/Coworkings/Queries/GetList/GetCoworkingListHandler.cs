using Microsoft.Extensions.Logging;
using Mediator;
using DeskBooking.Application.Coworkings.Dtos;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Coworkings.Queries.GetList;

public class GetCoworkingListHandler
    : IRequestHandler<GetCoworkingListQuery, IEnumerable<CoworkingListItemDto>>
{
    private readonly ILogger<GetCoworkingListHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetCoworkingListHandler(
        ILogger<GetCoworkingListHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<IEnumerable<CoworkingListItemDto>> Handle(GetCoworkingListQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all coworkings.");

        var coworkings = await _unitOfWork.CoworkingRepository.GetAllWithDetailsAsync();
        var date = DateOnly.FromDateTime(DateTime.Today);

        var coworkingListItemDtos = new List<CoworkingListItemDto>();

        foreach (var coworking in coworkings)
        {
            int deskCount = 0, privateRoomCount = 0, meetingRoomCount = 0;

            foreach (var workspace in coworking.Workspaces)
            {
                var booked = workspace.Bookings.Count(b => b.StartDate <= date && b.EndDate >= date);
                var available = Math.Max(0, workspace.Quantity - booked);

                if (workspace.WorkspaceType.Id == 1)
                    deskCount += available;
                else if (workspace.WorkspaceType.Id == 2)
                    privateRoomCount += available;
                else if (workspace.WorkspaceType.Id == 3)
                    meetingRoomCount += available;
            }

            if (deskCount > 0 || privateRoomCount > 0 || meetingRoomCount > 0)
            {
                coworkingListItemDtos.Add(new CoworkingListItemDto(
                    coworking.Id,
                    coworking.Name,
                    coworking.Description,
                    coworking.Address,
                    coworking.CoworkingPhotos.FirstOrDefault()?.FilePath,
                    deskCount,
                    privateRoomCount,
                    meetingRoomCount));
            }
        }

        _logger.LogInformation("Successfully fetched {CoworkingCount} coworkings.", coworkingListItemDtos.Count());

        return coworkingListItemDtos;
    }
}