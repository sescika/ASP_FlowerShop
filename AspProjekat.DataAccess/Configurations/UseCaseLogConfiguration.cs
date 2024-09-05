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
	public class UseCaseLogConfiguration : IEntityTypeConfiguration<UseCaseLog>
	{
		public void Configure(EntityTypeBuilder<UseCaseLog> builder)
		{
			builder.Property(x => x.Username).IsRequired().HasMaxLength(20);
			builder.Property(x => x.UseCaseName).IsRequired();

			builder.HasIndex(x => new { x.Username, x.UseCaseName, x.ExecutedAt })
				   .IncludeProperties(x => x.UseCaseData);
			builder.HasOne(x => x.UseCase).WithMany(x => x.UseCaseLogs).HasForeignKey(x => x.UseCaseName).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
