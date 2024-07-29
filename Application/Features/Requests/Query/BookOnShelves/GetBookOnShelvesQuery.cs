using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.BookOnShelves
{
    public record GetBookOnShelvesQuery(int Id) : IRequest<BookOnShelvesDto>;


}
