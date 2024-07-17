﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground.Wasm.Domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
        public DateTime CheckedDate { get; set; }
        public bool Checked { get; set; }
    }
}