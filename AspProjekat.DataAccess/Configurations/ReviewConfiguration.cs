using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
	internal class ReviewConfiguration : EntityConfiguration<Review>
	{
		protected override void ConfigureEntity(EntityTypeBuilder<Review> builder)
		{
			builder.Property(x => x.Rating).IsRequired();
			builder.Property(x => x.ReviewText).HasMaxLength(255);
		}
	}
}
