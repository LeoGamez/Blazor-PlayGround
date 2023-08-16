using Playground.Wasm.Shared.Models.UserManagement;

namespace Playground.Wasm.Server.Services
{
    public interface IUserModuleService
    {
        Task<List<UserModule>> GetUserModulesAsync(string userId);
    }
}