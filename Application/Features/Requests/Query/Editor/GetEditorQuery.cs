using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Editor
{
    public record GetEditorQuery(int Id) : IRequest<EditorDto>;


}
