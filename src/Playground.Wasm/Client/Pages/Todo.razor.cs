using Microsoft.AspNetCore.Components;
using Playground.Wasm.Shared.Models.Todos;
using System.Net.Http.Json;


namespace Playground.Wasm.Client.Pages;

public partial class Todo
{
    [Inject]
    HttpClient HttpClient { get; set; }

    List<TodoDto> dataList = new();
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
        var response = await HttpClient.GetFromJsonAsync<List<TodoDto>>("/api/testtodo");
        dataLoading = false;
        await InvokeAsync(StateHasChanged);
    }
}
