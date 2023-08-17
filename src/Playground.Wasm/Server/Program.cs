using Microsoft.AspNetCore.ResponseCompression;
using Playground.Wasm.Application.Config;
using Playground.Wasm.Infrastructure.Repositories;
using Playground.Wasm.Server.Services;
using System.Reflection;

namespace Playground.Wasm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IUserModuleService, UserModuleService>();
            builder.Services.AddScoped<IMockEntityRepository, MockEntityRepository>();

            builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MapperProfile).Assembly));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}