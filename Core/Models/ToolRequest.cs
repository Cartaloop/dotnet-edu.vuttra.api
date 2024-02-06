using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace edu.VuttraApp.Api.Core.Models
{
    public class ToolRequest
    {
        [Required(ErrorMessage = "O campo título é obrigatório.")]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo link é obrigatório.")]
        [MaxLength(2000)]
        public string Link { get; set; } = string.Empty;

        [MaxLength(150, ErrorMessage = "Limite máximo de caracteres excedido (Max. 150)")]
        public List<string>? Tags { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}