using Application.DTOs;
using Application.Features.Requests.Command.Checkout;
using Application.Features.Requests.Query.Checkout;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CheckoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CheckOutController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckoutDto>>> Get()
        {
            var checkOuts = await _mediator.Send(new GetAllCheckoutsQuery());
            return Ok(checkOuts);
        }

        // GET api/<CheckOutController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckoutDto>> Get(int id)
        {
            var checkOut = await _mediator.Send(new GetCheckoutQuery(id));
            return Ok(checkOut);
        }

        // POST api/<CheckOutController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] CheckoutCreateDto checkOut)
        {
            var result = await _mediator.Send(new CreateCheckoutCommand(checkOut));
            return Ok(result);
        }

        // PUT api/<CheckOutController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CheckoutUpdateDto checkOut)
        {
            if (id != checkOut.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateCheckoutCommand(checkOut));
            return NoContent();
        }

        // DELETE api/<CheckOutController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCheckoutCommand(id));
            return NoContent();
        }
    }
}
