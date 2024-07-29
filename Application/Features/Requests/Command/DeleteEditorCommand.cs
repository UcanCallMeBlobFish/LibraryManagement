using MediatR;

namespace Application.Features.Requests.Command
{
    public record DeleteEditorCommand(int Id) : IRequest<Unit>;
}
