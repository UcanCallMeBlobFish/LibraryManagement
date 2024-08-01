using Application.DTOs;
using Application.Features.Requests.Command.Customer;
using Application.Features.Requests.Query.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            var customers = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(customers);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> Get(string id)
        {
            var customer = await _mediator.Send(new GetCustomerQuery(id));
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CustomerCreateDto customer)
        {
            var result = await _mediator.Send(new CreateCustomerCommand(customer));
            return Ok(result);
        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public async Task<ActionResult> Put( [FromBody] CustomerUpdateDto customer)
        {
            await _mediator.Send(new UpdateCustomerCommand(customer));
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteCustomerCommand(id));
            return NoContent();
        }
    }
}
