using Microsoft.Extensions.Logging;
using Mediator;
using DeskBooking.Application.Common.Dtos;
using DeskBooking.Application.Common.Mappings;
using DeskBooking.Domain.Interfaces;

namespace DeskBooking.Application.WorkspaceTypes.Queries.GetAll;

public class GetAllWorkspaceTypesHandler
    : IRequestHandler<GetAllWorkspaceTypesQuery, IEnumerable<WorkspaceTypeDto>>
{
    private readonly ILogger<GetAllWorkspaceTypesHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWorkspaceTypesHandler(
        ILogger<GetAllWorkspaceTypesHandler> logger,
        IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<IEnumerable<WorkspaceTypeDto>> Handle(GetAllWorkspaceTypesQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all workspace types.");

        var workspaceTypes = await _unitOfWork.WorkspaceTypeRepository.GetAllAsync();

        var workspaceTypeDtos = workspaceTypes.ToWorkspaceTypeDtos();
        _logger.LogInformation("Successfully fetched {WorkspaceTypeCount} workspace types.", workspaceTypes.Count());

        return workspaceTypeDtos;
    }
}