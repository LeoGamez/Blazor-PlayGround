using Playground.Wasm.Shared.MockData;
using Playground.Wasm.Shared.Models.UserManagement;

namespace Playground.Wasm.Server.Services
{
    public class UserModuleService : IUserModuleService
    {
        //Todo: Implement to an extenal API

        public async Task<List<UserModule>> GetUserModulesAsync(string userId)
        {
            //Todo: Make API request to retrieve user modules based on the user ID
            await Task.Delay(50);
            return MockUserModules.GetUserModulesFromDatabase(userId);
        }
    }
}
