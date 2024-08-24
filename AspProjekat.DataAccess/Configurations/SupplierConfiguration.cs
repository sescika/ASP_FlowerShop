using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
	internal class SupplierConfiguration : EntityConfiguration<Supplier>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<Supplier> builder)
		{
			builder.Property(x => x.SupplierAddress).HasMaxLength(75);
			builder.Property(x => x.SupplierZipCode).HasMaxLength(75);
			builder.Property(x => x.SupplierCity).HasMaxLength(75);
			builder.Property(x => x.SupplierZipCode).HasMaxLength(12);
			builder.Property(x => x.SupplierState).HasMaxLength(75);
			builder.Property(x => x.SupplierPhone).HasMaxLength(75).IsRequired();
			builder.Property(x => x.SupplierEmail).HasMaxLength(50).IsRequired();
		}
	}
}
