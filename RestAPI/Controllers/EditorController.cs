using Application.DTOs;
using Application.Features.Requests.Command.Editor;
using Application.Features.Requests.Query.Editor;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EditorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<EditorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditorDto>>> Get()
        {
            var editors = await _mediator.Send(new GetAllEditorsQuery());
            return Ok(editors);
        }

        // GET api/<EditorController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EditorDto>> Get(int id)
        {
            var editor = await _mediator.Send(new GetEditorQuery(id));
            return Ok(editor);
        }

        // POST api/<EditorController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] EditorCreateDto editor)
        {
            var result = await _mediator.Send(new CreateEditorCommand(editor));
            return Ok(result);
        }

        // PUT api/<EditorController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] EditorUpdateDto editor)
        {
            

            await _mediator.Send(new UpdateEditorCommand(editor));
            return NoContent();
        }

        // DELETE api/<EditorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteEditorCommand(id));
            return NoContent();
        }
    }
}
