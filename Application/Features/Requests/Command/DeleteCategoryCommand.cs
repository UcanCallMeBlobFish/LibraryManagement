using MediatR;

namespace Application.Features.Requests.Command
{
    public record DeleteCategoryCommand(int Id) : IRequest<Unit>;
}
