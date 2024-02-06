using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using edu.VuttraApp.Api.Core.Models;
using edu.VuttraApp.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace edu.VuttraApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToolsController : ControllerBase
    {
        private readonly IToolService _service;

        public ToolsController(IToolService service)
        {
            _service = service;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<ToolResponse>?>> GetAll()
        {
            var getAll = await _service.GetAll();
            if (getAll == null)
            {
                return NotFound(getAll);
            }

            return Ok(getAll);
        }
        
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ToolResponse>?>> GetTByTag([FromQuery] IEnumerable<string> tags)
        {
            var getByTag = await _service.GetTByTag(tags);
            if (getByTag == null)
            {
                return NotFound("Nenhuma ferramenta encontrada");
            }
            return Ok(getByTag);
        }
        

        [HttpPost]
        public async Task<ActionResult<ToolResponse?>> Create(ToolRequest toolRequest)
        {
            var create = await _service.Create(toolRequest);
            if(create == null)
            {
                return BadRequest(create);
            }

            return Ok(create);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ToolResponse?>> RemoveById(int id)
        {
            var deleteTool = await _service.RemoveById(id);
            if (deleteTool == null)
            {
                return BadRequest("Valor não pode ser nulo");
            }

            return Ok(deleteTool);
        }
    }
}