using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Dtos;
using  AutoMapper;


namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
         private readonly IGenericRepository<Product> _productsRepo;
        
        private readonly IGenericRepository<ProductType> _productType;
        
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly  IMapper  _mapper;

        public ProductsController (
            
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductType> productType,
            IGenericRepository<ProductBrand> productBrand,
            IMapper mapper
        ) {
            this._mapper =  mapper;
            this._productsRepo = productsRepo;
            this._productType = productType;
            this._productBrand = productBrand;
        }

     
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec =  new ProductWithTypeAndBrandsSpecification();
             var products = await _productsRepo.ListAllAsync(spec);
            //  return  products.Select(x => new  ProductToReturnDto
            //  {
            //     Id   = x.Id,
            //     Name  =  x.Name,
            //     Description =  x.Description,
            //     Price =  x.Price,
            //     PictureUrl  = x.PictureUrl,
            //     ProductType = x.ProductType.Name,
            //     ProductBrand  = x.ProductBrand.Name


            //  }).ToList();
            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
 
 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProducts(int id)
        {
               var spec =  new ProductWithTypeAndBrandsSpecification(id);
            var  product=  await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);

        }
          [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _productBrand.ListAllAsync());
        }
         [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductType()
        {
            return Ok(await _productType.ListAllAsync());
        }
     }
}