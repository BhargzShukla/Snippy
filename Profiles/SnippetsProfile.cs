using AutoMapper;
using Snippy.Dtos;
using Snippy.Models;

namespace Snippy.Profiles
{
    public class SnippetsProfile : Profile
    {
        public SnippetsProfile()
        {
            CreateMap<Snippet, SnippetReadDto>();
            CreateMap<SnippetCreateOrUpdateDto, Snippet>().ReverseMap();
            // Uncomment below if above line doesn't work.
            // CreateMap<Snippet, SnippetCreateOrUpdateDto>();
        }
    }
}