using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
	internal class UseCaseConfiguration : EntityConfiguration<UseCase>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<UseCase> builder)
		{
			builder.HasKey(x => x.Name);
			builder.Property(x => x.Name).IsRequired();
			
			builder.Property(x => x.Id).IsRequired();
		}
	}
}
