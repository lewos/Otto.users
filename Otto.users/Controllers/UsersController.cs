using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Otto.users.Commands;
using Otto.users.Queries;

namespace Otto.users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUsersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(string id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction("GetUser", new { id = result.Id.ToString() }, result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return result != null
                ? (IActionResult)Created("", result)
                : Unauthorized("Combinacion de usuario y contraseña no valido");
        }
    }
}
