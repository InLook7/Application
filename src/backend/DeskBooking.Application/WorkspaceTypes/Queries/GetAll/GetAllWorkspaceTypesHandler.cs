using Mediator;
using DeskBooking.Domain.Interfaces;
using DeskBooking.Application.Common.Dtos;
using DeskBooking.Application.Common.Mappings;

namespace DeskBooking.Application.WorkspaceTypes.Queries.GetAll;

public class GetAllWorkspaceTypesHandler
    : IRequestHandler<GetAllWorkspaceTypesQuery, IEnumerable<WorkspaceTypeDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllWorkspaceTypesHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async ValueTask<IEnumerable<WorkspaceTypeDto>> Handle(GetAllWorkspaceTypesQuery request, CancellationToken cancellationToken)
    {
        var workspaceTypes = await _unitOfWork.WorkspaceTypeRepository.GetAllAsync();

        var workspaceTypeDtos = workspaceTypes.ToWorkspaceTypeDtos();
        return workspaceTypeDtos;
    }
}