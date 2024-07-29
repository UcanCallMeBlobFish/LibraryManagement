using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record UpdateCategoryCommand(CategoryUpdateDto CategoryUpdateDto) : IRequest<Unit>;
}
