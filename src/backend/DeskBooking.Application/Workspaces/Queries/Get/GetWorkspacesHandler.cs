using Microsoft.Extensions.Logging;
using Mediator;
using FluentResults;
using DeskBooking.Application.Workspaces.Dtos;
using DeskBooking.Application.Workspaces.Mappings;
using DeskBooking.Application.Common.Errors;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Workspaces.Queries.Get;

public class GetWorkspacesHandler
    : IRequestHandler<GetWorkspacesQuery, Result<IEnumerable<WorkspaceDto>>>
{
    private readonly ILogger<GetWorkspacesHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetWorkspacesHandler(
        ILogger<GetWorkspacesHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<IEnumerable<WorkspaceDto>>> Handle(GetWorkspacesQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting workspaces by coworking ID {CoworkingId} and workspace type ID {WorkspaceTypeId}", query.CoworkingId, query.WorkspaceTypeId);

        var coworking = await _unitOfWork.CoworkingRepository.GetByIdAsync(query.CoworkingId);
        if (coworking == null)
        {
            _logger.LogWarning("Coworking with ID {CoworkingId} does not exist.", query.CoworkingId);
            return Result.Fail(new NotFoundError());
        }

        var workspaceType = await _unitOfWork.WorkspaceTypeRepository.GetByIdAsync(query.WorkspaceTypeId);
        if (workspaceType == null)
        {
            _logger.LogWarning("Workspace type with ID {WorkspaceTypeId} does not exist.", query.WorkspaceTypeId);
            return Result.Fail(new NotFoundError());
        }

        var workspaces = await _unitOfWork.WorkspaceRepository.GetByCoworkingAndWorkspaceType(query.CoworkingId, query.WorkspaceTypeId);

        var workspaceDtos = workspaces.ToWorkspaceDtos();
        _logger.LogInformation("Successfully fetched {WorkspaceCount} workspaces.", workspaces.Count());

        return Result.Ok(workspaceDtos);
    }
}