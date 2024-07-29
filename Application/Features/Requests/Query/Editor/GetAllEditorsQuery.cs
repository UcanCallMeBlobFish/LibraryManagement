using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Editor
{
    public record GetAllEditorsQuery() : IRequest<IEnumerable<EditorDto>>;


}
