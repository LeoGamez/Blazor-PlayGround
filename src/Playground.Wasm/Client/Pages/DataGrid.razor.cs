using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Playground.Wasm.Shared.Models.MockEntities;
using Playground.Wasm.Shared.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Playground.Wasm.Client.Pages
{
    public partial class DataGrid
    {
        [Inject]
        HttpClient HttpClient { get; set; }

        List<MockEntityDto> dataList = new();
        bool dataLoading = false;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadData();
            }
        }

        private async Task LoadData()
        {
            dataLoading = true;
            await InvokeAsync(StateHasChanged);
            dataList = await HttpClient.GetFromJsonAsync<List<MockEntityDto>>("/api/mockentities") ?? new();
            dataLoading = false;
            await InvokeAsync(StateHasChanged);
        }
    }
}
