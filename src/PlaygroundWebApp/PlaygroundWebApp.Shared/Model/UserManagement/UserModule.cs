using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundWebApp.Shared.Model.UserManagement
{
    public class UserModule
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Icon { get; set; }
        public string? Route { get; set; }
        public List<UserModule> SubModules { get; set; } = new();
    }
}
