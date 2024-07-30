using MediatR;

namespace Application.Features.Requests.Command.Editor
{
    public record DeleteEditorCommand(int Id) : IRequest<Unit>;
}
