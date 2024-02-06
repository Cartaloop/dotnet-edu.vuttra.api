using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace edu.VuttraApp.Api.Core.Entities
{
    public class Tool
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new();
        public DateTime CreationDate { get; set; }

    }
}