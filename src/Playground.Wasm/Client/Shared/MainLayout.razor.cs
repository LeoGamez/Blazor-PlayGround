using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;
using Playground.Wasm.Shared.Helpers;
using System.ComponentModel;
using static MudBlazor.CategoryTypes;

namespace Playground.Wasm.Client.Shared
{
    public partial class MainLayout
    {
        [Inject]
        public NavigationManager Nav { get; set; }
     
        private List<BreadcrumbItem> _items = new List<BreadcrumbItem>();
        bool _drawerOpen = false;

        MudTheme MainTheme = new MudTheme()
        {
            Palette = new PaletteLight()
            {
                Primary = Colors.Blue.Darken3,
                Secondary = Colors.Blue.Darken3,
                AppbarBackground = Colors.Blue.Darken3,
            },
            PaletteDark = new PaletteDark()
            {
                Primary = Colors.Blue.Lighten1
            },

            LayoutProperties = new LayoutProperties()
            {
                DrawerWidthLeft = "260px",
                DrawerWidthRight = "300px"
            }
        };

        protected override void OnInitialized()
        {
            _items = new List<BreadcrumbItem>();
            _items.Add(new BreadcrumbItem("Home", href: "/"));
            Nav.LocationChanged += HandleNavChange;
        }

        private void HandleNavChange(object? sender, LocationChangedEventArgs e)
        {
            var currentUrl = Nav.Uri;
            _items = new List<BreadcrumbItem>();
            _items.Add(new BreadcrumbItem("Home", href: "/"));

            foreach (var part in currentUrl.Split('/').Skip(3).ToList()) 
            {
                _items.Add(new BreadcrumbItem(part.FirstCharSubstring(), href: $"/{part}"));
            }

            StateHasChanged();
        }

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}
