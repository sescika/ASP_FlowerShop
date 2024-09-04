using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
	internal class CustomerFileConfiguration : EntityConfiguration<CustomerFile>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<CustomerFile> builder)
		{
			builder.Property(x => x.Source).IsRequired();

		}
	}
}
