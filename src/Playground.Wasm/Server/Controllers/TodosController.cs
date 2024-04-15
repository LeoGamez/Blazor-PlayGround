using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Playground.Wasm.Application.Messages.Queries.Todos.GetTodos;

namespace Playground.Wasm.Server.Controllers
{
    public class TodosController : ControllerBase
    {
        private readonly IMediator mediator;

        public TodosController(IMediator mediator)
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
