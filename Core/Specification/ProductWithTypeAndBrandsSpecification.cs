using Core.Entites;

namespace Core.Specification
{
    public class ProductWithTypeAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductWithTypeAndBrandsSpecification(string  sort)
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);
            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "priceAsc": 
                    AddOrderBy(p=>p.Price);
                    break;
                    
                  
                    case "priceDesc": 
                    AddOrderByDescendig(p=>p.Price);
                    break;
                    default:
                    AddOrderBy(n=>n.Name);
                    break;
                }
            }

        }
        
        public ProductWithTypeAndBrandsSpecification(int id)
         :  base(x =>x.Id == id)
        {
             AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);

        }


    }
}