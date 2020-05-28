
using Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

 namespace Infrastructure.Data
{
    public class StroreContext : DbContext
    {
        public StroreContext(DbContextOptions<StroreContext> options) : base(options)
        {


        }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands{ get; set; }

           public DbSet<ProductType> ProductTypes{ get; set; }



                protected override  void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
                if (Database.ProviderName == "Microsft.EntityFramwork.Sqlite")
                {
                    foreach(var entitytype  in  modelBuilder.Model.GetEntityTypes())
                    {
                        var properties =  entitytype.ClrType.GetProperties().Where(p=>p.PropertyType ==
                        typeof(decimal));
                    foreach (var property in properties)
                    {

                        modelBuilder.Entity(entitytype.Name).Property(property.Name)
                        .HasConversion<double>();
                        
                    }

  
                    }
                }

            }
    }
}



