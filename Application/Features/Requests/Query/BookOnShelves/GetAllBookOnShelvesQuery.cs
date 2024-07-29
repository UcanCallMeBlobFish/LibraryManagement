using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.BookOnShelves
{
    public record GetAllBookOnShelvesQuery() : IRequest<IEnumerable<BookOnShelvesDto>>;


}
