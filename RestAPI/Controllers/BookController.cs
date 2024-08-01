using Application.DTOs;
using Application.Features.Requests.Command.Book;
using Application.Features.Requests.Query.Book;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Get()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());
            return Ok(books);
        }

        // GET api/<BookController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> Get(int id)
        {
            var book = await _mediator.Send(new GetBookQuery(id));
            return Ok(book);
        }

        // POST api/<BookController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] BookCreateDto book)
        {
            var result = await _mediator.Send(new CreateBookCommand(book));
            return Ok(result);
        }

        // PUT api/<BookController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BookUpdateDto book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateBookCommand(book));
            return NoContent();
        }

        // DELETE api/<BookController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBookCommand(id));
            return NoContent();
        }
    }
}
