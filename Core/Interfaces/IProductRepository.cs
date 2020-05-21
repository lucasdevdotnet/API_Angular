using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entites;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetproductByIdAsyn(int id);

        Task<IReadOnlyList<Product>> GetproductsAsyn();
        Task<IReadOnlyList<ProductBrand>> GetProductBrandAsyn();
        Task<IReadOnlyList<ProductType>> ProductTypeAsyn();

    }
}