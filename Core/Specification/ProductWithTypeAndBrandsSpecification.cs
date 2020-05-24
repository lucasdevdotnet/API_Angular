using Core.Entites;

namespace Core.Specification
{
    public class ProductWithTypeAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductWithTypeAndBrandsSpecification()
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);

        }
        
        public ProductWithTypeAndBrandsSpecification(int id)
         :  base(x =>x.Id == id)
        {
             AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);

        }


    }
}