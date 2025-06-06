using Mediator;
using DeskBooking.Application.WorkspaceTypes.Dtos;

namespace DeskBooking.Application.WorkspaceTypes.Queries.GetAll;

public record GetAllWorkspaceTypesQuery : IRequest<IEnumerable<WorkspaceTypeDto>>;