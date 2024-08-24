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
	internal class OrderConfiguration : EntityConfiguration<Order>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
		{
			builder.Property(x => x.Status).IsRequired().HasDefaultValue("pending").HasMaxLength(10);
			builder.Property(x => x.TotalAmount).IsRequired();
			builder.Property(x => x.PaymentMethod).IsRequired().HasDefaultValue("credit_card");

			builder.HasMany(x => x.OrderItems).WithOne(x => x.Order).HasForeignKey(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);

		}
	}
}
