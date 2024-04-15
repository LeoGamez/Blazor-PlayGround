using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Wasm.Shared.Models.Todos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public DateTime DoneDate { get; set; }
    }
}