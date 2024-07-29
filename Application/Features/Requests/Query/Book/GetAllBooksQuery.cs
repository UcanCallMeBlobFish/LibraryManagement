using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Book
{
    public record GetAllBooksQuery() : IRequest<IEnumerable<BookDto>>;


}
