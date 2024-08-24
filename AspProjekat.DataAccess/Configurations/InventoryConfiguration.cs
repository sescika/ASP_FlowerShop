using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
	internal class InventoryConfiguration : EntityConfiguration<Inventory>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<Inventory> builder)
		{
			builder.Property(x => x.QuantityAvailable).IsRequired();
		}
	}
}
