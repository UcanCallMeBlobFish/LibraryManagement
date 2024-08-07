using Application.DTOs;
using Application.Features.Requests.Command.Author;
using Application.Features.Requests.Query.Author;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> Get()
        {
            var authors = await _mediator.Send(new GetAllAuthorsQuery());
            return Ok(authors);
        }

        // GET api/<AuthorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> Get(int id)
        {
            var author = await _mediator.Send(new GetAuthorQuery(id));
            return Ok(author);
        }

        // POST api/<AuthorController>
        [Authorize(Roles = "Librarian")]
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] AuthorCreateDto author)
        {
            var result = await _mediator.Send(new CreateAuthorCommand(author));
            return Ok(result);
        }

        // PUT api/<AuthorController>/5
        [Authorize(Roles = "Librarian")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] AuthorUpdateDto author)
        {
            await _mediator.Send(new UpdateAuthorCommand(author));
            return NoContent();
        }

        // DELETE api/<AuthorController>/5
        [Authorize(Roles = "Librarian")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAuthorCommand(id));
            return NoContent();
        }
    }
}
