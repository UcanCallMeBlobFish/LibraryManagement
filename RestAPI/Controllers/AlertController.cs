using Application.DTOs;
using Application.Features.Requests.Command.Alert;
using Application.Features.Requests.Query.Alert;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Librarian")]

    public class AlertController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AlertController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AlertController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertDto>>> Get()
        {
            var alerts = await _mediator.Send(new GetAllAlertsQuery());
            return Ok(alerts);
        }

        // GET api/<AlertController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlertDto>> Get(int id)
        {
            var alert = await _mediator.Send(new GetAlertQuery(id));
            return Ok(alert);
        }

        // POST api/<AlertController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AlertCreateDto alert)
        {
            var result = await _mediator.Send(new CreateAlertCommand(alert));
            return Ok(result);
        }

        // PUT api/<AlertController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] AlertUpdateDto alert)
        {
           await _mediator.Send(new UpdateAlertCommand(alert));
            return NoContent();
        }

        // DELETE api/<AlertController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAlertCommand(id));
            return NoContent();
        }
    }
}
