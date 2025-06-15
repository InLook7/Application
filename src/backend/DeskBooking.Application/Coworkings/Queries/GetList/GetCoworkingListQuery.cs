using DeskBooking.Application.Coworkings.Dtos;
using Mediator;

namespace DeskBooking.Application.Coworkings.Queries.GetList;

public record GetCoworkingListQuery : IRequest<IEnumerable<CoworkingListItemDto>>;