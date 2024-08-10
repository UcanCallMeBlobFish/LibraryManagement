using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Requests.Command.Checkout
{
    public record ReturnBookCommand(int Id) : IRequest<int>;

}
