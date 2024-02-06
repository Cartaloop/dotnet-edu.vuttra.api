using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edu.VuttraApp.Api.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Tool> Tools { get; set; } = new();
        
    }
}