using Mediator;
using FluentResults;
using DeskBooking.Application.Workspaces.Dtos;

namespace DeskBooking.Application.Workspaces.Queries.GetByWorkspaceType;

public record GetByWorkspaceTypeIdQuery(int Id) : IRequest<Result<IEnumerable<WorkspaceDto>>>;