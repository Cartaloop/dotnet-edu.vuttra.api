using AutoMapper;
using edu.VuttraApp.Api.Core.Entities;
using edu.VuttraApp.Api.Handlers;

namespace edu.VuttraApp.Api.Core.Models.Mappers
{
    public class ToolProfile : Profile
    {
        public ToolProfile()
        {
            CreateMap<Tool, ToolRequest>().ReverseMap();
            CreateMap<Tool, ToolResponse>()
                .ForMember(dest => dest.Tags, opt => 
                    opt.MapFrom(src => src.Tags.Select(tag => tag.Name!.ToLower())));

            CreateMap<ToolRequest, Tool>()
                .ForMember(dest => dest.Tags, opt => 
                    opt.MapFrom(src => src.Tags!.Select(tagName => 
                        new Tag { Name = RemoveAccentsHandler.RemoveAccents(tagName.ToLower())})));
            
        }

        
    }
}