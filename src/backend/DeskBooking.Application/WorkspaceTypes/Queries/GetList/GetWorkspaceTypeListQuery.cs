using Mediator;
using FluentResults;
using DeskBooking.Application.WorkspaceTypes.Dtos;

namespace DeskBooking.Application.WorkspaceTypes.Queries.GetList;

public record GetWorkspaceTypeListQuery(int Id) : IRequest<Result<IEnumerable<WorkspaceTypeListItemDto>>>;