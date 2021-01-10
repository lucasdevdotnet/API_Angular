using Core.Entites;

namespace Core.Specification
{
    public class ProductWithTypeAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductWithTypeAndBrandsSpecification( ProductsSpecParams productsParams )
        : base (x=>
        (!productsParams.BrandId.HasValue || x.ProductBrandId == productsParams.BrandId) && 
        (! productsParams.TypeId.HasValue || x.ProductBrandId ==  productsParams.TypeId )
        )
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
            AddOrderBy(x=>x.Name);
            ApplyPaging(productsParams.PageSize * (productsParams.PageIndex -1),productsParams.PageSize);
            if(!string.IsNullOrEmpty(productsParams.Sort))
            {
                switch(productsParams.Sort)
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