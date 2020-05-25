
using AutoMapper;
using API.Dtos;
using Core.Entites;
namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>();
            
        }
    }
}