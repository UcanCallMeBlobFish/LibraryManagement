using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Alert
{
    public record GetAlertQuery(int Id) : IRequest<AlertDto>;


}
