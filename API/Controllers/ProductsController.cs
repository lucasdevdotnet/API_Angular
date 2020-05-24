using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
         private readonly IGenericRepository<Product> _productsRepo;
        
        private readonly IGenericRepository<ProductType> _productType;
        
        private readonly IGenericRepository<ProductBrand> _productBrand;

        public ProductsController (
            
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductType> productType,
            IGenericRepository<ProductBrand> productBrand
        ) {
            this._productsRepo = productsRepo;
            this._productType = productType;
            this._productBrand = productBrand;
        }

     
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec =  new ProductWithTypeAndBrandsSpecification();
             var products = await _productsRepo.ListAllAsync(spec);
             return  Ok(products);
 
 
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
               var spec =  new ProductWithTypeAndBrandsSpecification(id);
            return await _productsRepo.GetEntityWithSpec(spec);

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