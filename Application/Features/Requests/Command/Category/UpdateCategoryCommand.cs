using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Category
{
    public record UpdateCategoryCommand(CategoryUpdateDto CategoryUpdateDto) : IRequest<Unit>;
}
