using Application.DTOs;
using Application.Features.Requests.Command.BookOnShelves;
using Application.Features.Requests.Query.BookOnShelves;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookOnShelfController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookOnShelfController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BookOnShelfController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookOnShelvesDto>>> Get()
        {
            var booksOnShelf = await _mediator.Send(new GetAllBookOnShelvesQuery());
            return Ok(booksOnShelf);
        }

        // GET api/<BookOnShelfController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookOnShelvesDto>> Get(int id)
        {
            var bookOnShelf = await _mediator.Send(new GetBookOnShelvesQuery(id));
            return Ok(bookOnShelf);
        }

        // POST api/<BookOnShelfController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] BookOnShelvesCreateDto bookOnShelf)
        {
            var result = await _mediator.Send(new CreateBookOnShelvesCommand(bookOnShelf));
            return Ok(result);
        }

        // PUT api/<BookOnShelfController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BookOnShelvesUpdateDto bookOnShelf)
        {
            if (id != bookOnShelf.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateBookOnShelvesCommand(bookOnShelf));
            return NoContent();
        }

        // DELETE api/<BookOnShelfController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBookOnShelvesCommand(id));
            return NoContent();
        }
    }
}
