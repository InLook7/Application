using Mediator;
using FluentResults;
using DeskBooking.Application.Workspaces.Dtos;

namespace DeskBooking.Application.Workspaces.Queries.Get;

public record GetWorkspacesQuery(
    int CoworkingId,
    int WorkspaceTypeId) : IRequest<Result<IEnumerable<WorkspaceDto>>>;