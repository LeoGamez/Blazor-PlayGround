using Microsoft.AspNetCore.Components;
using Playground.Wasm.Shared.Models.MockEntities;
using System.Net.Http.Json;


namespace Playground.Wasm.Client.Pages;

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
