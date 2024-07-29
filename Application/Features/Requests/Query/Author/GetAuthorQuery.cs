using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Author
{
    public record GetAuthorQuery(int Id) : IRequest<AuthorDto>;


}
