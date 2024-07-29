using Application.DTOs;
using MediatR;

namespace Application.Features.Requests.Command
{
    public record CreateCategoryCommand(CategoryCreateDto CategoryCreateDto) : IRequest<int>;
}
