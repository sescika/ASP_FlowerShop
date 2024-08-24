﻿using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess.Configurations
{
	internal abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T>
		where T : Entity
	{
		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			builder.Property(x => x.CreatedAt)
			 .HasDefaultValueSql("GETDATE()");

			builder.Property(x => x.IsActive).HasDefaultValue(true);

			ConfigureEntity(builder);
		}
		protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
	}
	internal abstract class NamedEntityConfiguration<T> : EntityConfiguration<T>
		where T : NamedEntity
	{
		public override void Configure(EntityTypeBuilder<T> builder)
		{
			base.Configure(builder);

			builder.Property(x => x.Name)
				   .IsRequired()
				   .HasMaxLength(40);

			builder.HasIndex(x => x.Name)
				   .IsUnique();
		}
	}
}
