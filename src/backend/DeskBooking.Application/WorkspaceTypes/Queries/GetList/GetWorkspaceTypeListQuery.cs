using Mediator;
using DeskBooking.Application.WorkspaceTypes.Dtos;

namespace DeskBooking.Application.WorkspaceTypes.Queries.GetList;

public record GetWorkspaceTypeListQuery : IRequest<IEnumerable<WorkspaceTypeListItemDto>>;