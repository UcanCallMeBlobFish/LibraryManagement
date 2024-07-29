using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Application.DTOs;


namespace Application.Features.Requests.Query.Alert
{
    public record GetAllAlertsQuery() : IRequest<IEnumerable<AlertDto>>;


}
