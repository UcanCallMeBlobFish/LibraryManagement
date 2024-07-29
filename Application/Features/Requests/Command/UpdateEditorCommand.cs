using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record UpdateEditorCommand(EditorUpdateDto EditorUpdateDto) : IRequest<Unit>;
}
