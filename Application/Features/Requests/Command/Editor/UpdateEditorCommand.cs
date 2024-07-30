using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Editor
{
    public record UpdateEditorCommand(EditorUpdateDto EditorUpdateDto) : IRequest<Unit>;
}
