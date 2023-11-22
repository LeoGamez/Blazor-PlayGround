using Microsoft.AspNetCore.Components;
using PlaygroundWebApp.Shared.Model.UserManagement;

namespace PlaygroundWebApp.Components.Layout
{
    public partial class NavMenu
    {
        [Parameter]
        public bool IsSideMenuCollapsed { get; set; }
        [Inject]
        HttpClient HttpClient { get; set; }

        private List<UserModule> UserModules = new();

        readonly string UserId = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadUserModulesAsync();
        }

        private async Task LoadUserModulesAsync()
        {
            UserModules = await HttpClient.GetFromJsonAsync<List<UserModule>>("/api/usermodules") ?? new();
        }
    }
}
