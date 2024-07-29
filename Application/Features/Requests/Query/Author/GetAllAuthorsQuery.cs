using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Author
{
    public record GetAllAuthorsQuery() : IRequest<IEnumerable<AuthorDto>>;


}
