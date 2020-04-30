using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace API.Controllers
{
     [ApiController]
    [Route("api/[controller]")]
    public class ProductsControllers :ControllerBase
    {         
        private readonly StroreContext _context;
        public ProductsControllers(StroreContext context)
        {
                _context = context;
        }
     
    
        [HttpGet]
        public  async Task<ActionResult<List<Product>>>GetProducts()
        {
            var products  = await  _context.Products.ToListAsync();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>>GetProducts(int id)
        {
          return await  _context.Products.FindAsync(id);
           
        }
        
    }
}