
using AutoMapper;
using API.Dtos;
using Core.Entites;
namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(c=>c.ProductBrand, p=>p.MapFrom(s=>s.ProductBrand.Name))
            .ForMember(c=>c.ProductType, p=>p.MapFrom(s=>s.ProductType.Name))
             .ForMember(c=>c.PictureUrl, p=>p.MapFrom<ProductUlrResolver>());
            
            
        }
    }
}