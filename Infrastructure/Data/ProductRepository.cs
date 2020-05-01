using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {


    private  readonly  StroreContext  _context;
        public ProductRepository(StroreContext  context)
        {
            this._context = context;
        }
        public async Task<Product> GetproductByIdAsyn(int id)
        {
            return await  _context.Products.FindAsync(id);
        }

        public  async Task<IReadOnlyList<Product>> GetproductsAsyn()
        {
   
          return await  _context.Products.ToListAsync();
        }

  
    }
}