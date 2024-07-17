using MediatR;
using Microsoft.AspNetCore.Mvc;
using Playground.Wasm.Application.Messages.Queries.Todos.GetTodos;

namespace Playground.Wasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestTodoController : ControllerBase
    {
        private readonly IMediator mediator;

        public TestTodoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await this.mediator.Send(new GetTodosQuery()));
        }
    }

}

