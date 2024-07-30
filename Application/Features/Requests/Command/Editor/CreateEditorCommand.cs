using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Editor
{
    public record CreateEditorCommand(EditorCreateDto EditorCreateDto) : IRequest<int>;
}
