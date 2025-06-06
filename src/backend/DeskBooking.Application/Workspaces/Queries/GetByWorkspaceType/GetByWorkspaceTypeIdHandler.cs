using Microsoft.Extensions.Logging;
using Mediator;
using FluentResults;
using DeskBooking.Application.Workspaces.Dtos;
using DeskBooking.Application.Workspaces.Mappings;
using DeskBooking.Application.Common.Errors;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.Workspaces.Queries.GetByWorkspaceType;

public class GetByWorkspaceTypeIdHandler
    : IRequestHandler<GetByWorkspaceTypeIdQuery, Result<IEnumerable<WorkspaceDto>>>
{
    private readonly ILogger<GetByWorkspaceTypeIdHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetByWorkspaceTypeIdHandler(
        ILogger<GetByWorkspaceTypeIdHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<Result<IEnumerable<WorkspaceDto>>> Handle(GetByWorkspaceTypeIdQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting workspaces with workspace type ID {WorkspaceTypeId}", query.Id);

        var workspaceType = await _unitOfWork.WorkspaceTypeRepository.GetByIdAsync(query.Id);
        if (workspaceType == null)
        {
            _logger.LogWarning("Workspace type with ID {BookingId} does not exist.", query.Id);
            return Result.Fail(new NotFoundError());
        }

        var workspaces = await _unitOfWork.WorkspaceRepository.GetByWorkspaceTypeId(query.Id);

        var workspaceDtos = workspaces.ToWorkspaceDtos();
        _logger.LogInformation("Successfully fetched workspaces with workspace type ID {WorkspaceTypeId}.", query.Id);

        return Result.Ok(workspaceDtos);
    }
}