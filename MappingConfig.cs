using Labb3_RestApi.Models;
using AutoMapper;
using Labb3_RestApi.Models.DTO;
using Labb3_RestApi.Models.PersonDTO;
using Labb3_RestApi.Models.InterestDTO;
using Labb3_RestApi.Models.LinkDto;

namespace Labb3_RestApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //Person
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonCreateDto>().ReverseMap();
            CreateMap<Person, PersonUpdateDto>().ReverseMap();
            //Interest
            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<Interest, InterestCreateDto>().ReverseMap();
            CreateMap<Interest, InterestUpdateDto>().ReverseMap();
            //Links
            CreateMap<Links, LinksDto>().ReverseMap();
            CreateMap<Links, LinkCreateDto>().ReverseMap();
            CreateMap<Links, LinkUpdateDto>().ReverseMap();
        }
        
    }
}
