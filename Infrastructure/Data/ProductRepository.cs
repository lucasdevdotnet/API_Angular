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

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandAsyn()
        {
            return   await  _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetproductByIdAsyn(int id)
        {


            
          return await  _context.Products
                 .Include(p=>p.ProductType)
                 .Include(p=>p.ProductBrand) 
                .FirstOrDefaultAsync(p=>p.Id ==  id);
      
        }

        public  async Task<IReadOnlyList<Product>> GetproductsAsyn()
        {
   
          return await  _context.Products
                 .Include(p=>p.ProductType)
                 .Include(p=>p.ProductBrand) 
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> ProductTypeAsyn()
        {
           return  await _context.ProductTypes.ToListAsync();
        }
    }
}