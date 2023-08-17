using MudBlazor;
using Playground.Wasm.Shared.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Wasm.Shared.MockData
{
    public static class MockUserModules
    {
        public static List<UserModule> GetUserModulesFromDatabase(string userId)
        {
            // Simulated method to retrieve user modules from the database
            // Replace this with your actual data retrieval logic
            var userModules = new List<UserModule>()
            {
                new UserModule
                {
                    Id = "1",
                    Name = "Dashboard",
                    Icon = Icons.Material.Filled.Dashboard,
                    Route = "/dashboard"
                },
                new UserModule
                {
                    Id = "2",
                    Name = "MUD Components",
                    Icon = Icons.Material.Filled.List,
                    Route = "/components",
                    SubModules = new List<UserModule>
                    {
                        new UserModule
                        {
                            Id = "2.1",
                            Name = "MUD-DataGrid",
                            Icon = Icons.Material.Filled.FileOpen,
                            Route = "/datagrid"
                        }
                    }
                },
            };

            return userModules;
        }
    }
}
