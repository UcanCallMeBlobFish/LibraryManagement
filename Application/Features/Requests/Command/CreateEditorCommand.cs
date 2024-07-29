using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record CreateEditorCommand(EditorCreateDto EditorCreateDto) : IRequest<int>;
}
