using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using edu.VuttraApp.Api.Core.Context;
using edu.VuttraApp.Api.Core.Entities;
using edu.VuttraApp.Api.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace edu.VuttraApp.Api.Services
{
    public class ToolService : IToolService
    {
        private readonly VuttraDbContext _context;
        private readonly IMapper _mapper;
        public ToolService(VuttraDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ToolResponse?> Create(ToolRequest toolRequest)
        {
            if(toolRequest != null)
                try
                {
                    var tool = _mapper.Map<Tool>(toolRequest);
                    _context.Tools.Add(tool!);
                    await _context.SaveChangesAsync();

                    var createdToolResponse = _mapper.Map<ToolResponse>(tool);
                    return createdToolResponse!;
                }
                catch(Exception ex)
                {
                    throw new Exception("Erro ao criar nova ferramenta no banco de dados", ex);
                }
            return null;
        }

        public async Task<IEnumerable<ToolResponse>?> GetAll()
        {
            var listOfTools = await _context.Tools.Include(t => t.Tags).ToListAsync();

                if(listOfTools == null!)
                    return null;
                
            try
            {
                var toolResponse = _mapper.Map<IEnumerable<ToolResponse>>(listOfTools);

                return toolResponse;
            }
            catch(Exception ex) 
            {
                throw new Exception("Erro ao buscar informações", ex);
            }

        }

        public async Task<IEnumerable<ToolResponse>?> GetTByTag(IEnumerable<string> strings)
        {
            var filteredTools = await _context.Tools
            .Include( t => t.Tags)
            .Where( t => t.Tags.Any(tag => strings.Contains(tag.Name)))
            .ToListAsync();

            if (filteredTools.IsNullOrEmpty())
                return null;

            try
            {        
                var toolsResponse = _mapper.Map<IEnumerable<ToolResponse>>(filteredTools);
                return toolsResponse;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao filtrar tags", ex);
            }
        }

        public async Task<ToolResponse?> RemoveById(int id)
        {

            var tool = await _context.Tools.FirstAsync(tool => tool.Id == id);
            if (tool == null)
                return null;
        

            try
            {
                _context.Tools.Remove(tool);
                await _context.SaveChangesAsync();

                var deletedToolResponse = _mapper.Map<ToolResponse>(tool);
                return deletedToolResponse;
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao excluir a ferramenta do banco de dados", ex);
            }
        }
        
    }
}