
using Core.Entites;
using Microsoft.EntityFrameworkCore;


 namespace Infrastructure.Data
{
    public class StroreContext : DbContext
    {
        public StroreContext(DbContextOptions<StroreContext> options) : base(options)
        {


        }
        public DbSet<Product> Products { get; set; }
    }
}



