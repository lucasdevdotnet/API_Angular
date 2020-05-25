

using API.Dtos;
using AutoMapper;
using Core.Entites;
using Microsoft.Extensions.Configuration;

namespace API.Helper
{
    public class ProductUlrResolver : IValueResolver<Product, ProductToReturnDto, string>

    {
        private readonly IConfiguration _config;

        public ProductUlrResolver(IConfiguration config)
        {
            this._config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
             if(!string.IsNullOrEmpty(source.PictureUrl))
             {
                 return _config["ApiUrl"] +  source.PictureUrl;
             } 
             return null;
        }                                                                                                                             
    }
}