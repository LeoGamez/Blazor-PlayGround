using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SpawnDev.BlazorJS;
using SpawnDev.BlazorJS.WebWorkers;
using Test.Blazor.Net8.Client.MyServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// SpawnDev.BlazorJS
builder.Services.AddBlazorJSRuntime();
// SpawnDev.BlazorJS.WebWorkers
builder.Services.AddWebWorkerService();
builder.Services.AddSingleton<IIntensiveService, IntensiveService>();

await builder.Build().BlazorJSRunAsync();