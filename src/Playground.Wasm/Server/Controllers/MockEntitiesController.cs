using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Playground.Wasm.Application.Messages.Queries.GetMockEntities;

namespace Playground.Wasm.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockEntitiesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MockEntitiesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await this.mediator.Send(new GetMockEntities()));
        }
    }
}
