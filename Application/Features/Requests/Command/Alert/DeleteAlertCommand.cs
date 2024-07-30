using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Requests.Command.Alert
{
    public record DeleteAlertCommand(int Id) : IRequest<Unit>;
}
