using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
	internal class CustomerConfiguration : EntityConfiguration<Customer>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<Customer> builder)
		{
			builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
			builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
			builder.HasIndex(x => x.Email)
					.IsUnique();
			builder.Property(x => x.Address).HasMaxLength(75);
			builder.Property(x => x.City).HasMaxLength(75);
			builder.Property(x => x.State).HasMaxLength(75);
			builder.Property(x => x.ZipCode).HasMaxLength(12);
			builder.Property(x => x.Username)
				   .HasMaxLength(50)
				   .IsRequired();
			builder.HasIndex(x => x.Username)
				   .IsUnique();


			builder.HasIndex(x => new { x.Name, x.LastName, x.Email, x.Username });


			builder.HasMany(x => x.Orders).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(x => x.Reviews).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
			builder.HasMany(x => x.Files).WithOne(x => x.Customer).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
