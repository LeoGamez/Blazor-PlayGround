using Microsoft.AspNetCore.Mvc;
using Playground.Wasm.Server.Services;

namespace Playground.Wasm.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserModulesController : ControllerBase
    {
        private readonly IUserModuleService _userModuleService;

        public UserModulesController(IUserModuleService userModuleService)
        {
            _userModuleService = userModuleService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserModules()
        {
            string userId = string.Empty;
            // Fetch user modules based on the user ID
            var userModules = await _userModuleService.GetUserModulesAsync(userId);

            return Ok(userModules);
        }
    }
}
