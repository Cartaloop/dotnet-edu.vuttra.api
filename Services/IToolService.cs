using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using edu.VuttraApp.Api.Core.Models;

namespace edu.VuttraApp.Api.Services
{
    public interface IToolService
    {
        public Task<IEnumerable<ToolResponse>?> GetAll();
        public Task<IEnumerable<ToolResponse>?> GetTByTag(IEnumerable<string> strings);
        public Task<ToolResponse?> Create(ToolRequest toolRequest);
        public Task<ToolResponse?> RemoveById(int id);
        
    }
}