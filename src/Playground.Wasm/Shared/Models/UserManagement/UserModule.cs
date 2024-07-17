namespace Playground.Wasm.Shared.Models.UserManagement;

public class UserModule
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? Icon { get; set; }
    public string? Route { get; set; }
    public List<UserModule> SubModules { get; set; } = new();
}
