using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspProjekat.DataAccess.Configurations
{
	internal class ProductConfiguration : EntityConfiguration<Product>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
		{
			builder.Property(x => x.Description).HasMaxLength(255);
			builder.Property(x => x.Price).IsRequired();
			builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(255);

			builder.HasOne(x => x.Supplier).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(x => x.Reviews).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(x => x.Categories).WithMany(x => x.Products);
			builder.HasOne(x => x.Inventory).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
			builder.HasMany(x => x.OrderItems).WithOne(x => x.Product).OnDelete(DeleteBehavior.Cascade);
		}
	}
}
