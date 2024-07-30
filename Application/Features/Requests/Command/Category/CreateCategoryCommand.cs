using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command.Category
{
    public record CreateCategoryCommand(CategoryCreateDto CategoryCreateDto) : IRequest<int>;
}
