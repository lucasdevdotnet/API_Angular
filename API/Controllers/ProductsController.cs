using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {




        private readonly GenericRepository<Product> _productsRepo;
        private readonly GenericRepository<ProductType> _productType;
        private readonly GenericRepository<ProductBrand> _productBrand;

        public ProductsController (
            
            GenericRepository<Product> productsRepo,
            GenericRepository<ProductType> productType,
            GenericRepository<ProductBrand> productBrand
        ) {
            this._productsRepo = productsRepo;
            this._productType = productType;
            this._productBrand = productBrand;
        }

     

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _productsRepo.GetByIdAsync(id);

        }
          [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrand()
        {
            return Ok(await _productBrand.ListAllAsync());
        }
            [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductType()
        {
            return Ok(await _productType.ListAllAsync());
        }
    }
}