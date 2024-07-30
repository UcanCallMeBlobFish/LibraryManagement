using MediatR;

namespace Application.Features.Requests.Command.Category
{
    public record DeleteCategoryCommand(int Id) : IRequest<Unit>;
}
