using Core.Entites;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Data.Config
{
        public class ProductConfiguration : IEntityTypeConfiguration<Product> 
        {
            public void Configure (Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
             {
                builder.Property (p => p.Id).IsRequired ();
                builder.Property (p => p.Description).IsRequired ().HasMaxLength (100);
                builder.Property (p => p.Price).HasColumnType ("decimal(18,2)");
                builder.Property (p => p.PictureUrl).IsRequired ();
                builder.Property (p => p.ProductTypeId).IsRequired ().HasMaxLength (100);
                builder.Property (p => p.ProductBrandId).IsRequired ().HasMaxLength (100);
                builder.HasOne (b => b.ProductBrand).WithMany ()
                    .HasForeignKey (p => p.ProductBrandId);
                builder.HasOne (t => t.ProductType).WithMany ()
                    .HasForeignKey (p => p.ProductTypeId);

            }
        }
}