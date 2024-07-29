using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Book
{
    public record GetBookQuery(int Id) : IRequest<BookDto>;


}
