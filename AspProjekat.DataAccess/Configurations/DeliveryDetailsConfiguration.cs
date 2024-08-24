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
	internal class DeliveryDetailsConfiguration : EntityConfiguration<DeliveryDetails>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<DeliveryDetails> builder)
		{
			builder.Property(x => x.DeliveryDate).IsRequired();
			builder.Property(x => x.DeliveryAddress).IsRequired().HasMaxLength(75);
			builder.Property(x => x.DeliveryCity).IsRequired().HasMaxLength(75);
			builder.Property(x => x.DeliveryState).IsRequired().HasMaxLength(75);
			builder.Property(x => x.DeliveryStatus).IsRequired().HasMaxLength(75).HasDefaultValue("pending");
			builder.Property(x => x.DeliveryZipCode).IsRequired();

			builder.HasOne(x => x.Order).WithOne(x => x.DeliveryDetails).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
