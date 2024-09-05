using AspProjekat.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Bogus;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspProjekat.DataAccess
{
	public class FlowershopContext : DbContext
	{
		private readonly string _connectionString;

		public FlowershopContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		public FlowershopContext()
		{
			_connectionString = "Data Source=LAZAR;Initial Catalog=Flowershop;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);


			base.OnModelCreating(modelBuilder);	
		}

		public override int SaveChanges()
		{
			IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

			foreach (EntityEntry entry in entries)
			{
				if (entry.State == EntityState.Added)
				{
					if (entry.Entity is Entity e)
					{
						e.IsActive = true;
						e.CreatedAt = DateTime.UtcNow;
					}
				}

				if (entry.State == EntityState.Modified)
				{
					if (entry.Entity is Entity e)
					{
						e.UpdatedAt = DateTime.UtcNow;
					}
				}
			}

			return base.SaveChanges();
		}

		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Inventory> Inventory { get; set; }
		public DbSet<DeliveryDetails> DeliveryDetails { get; set; }
		public DbSet<UseCaseLog> UseCaseLogs { get; set; }
		public DbSet<ErrorLog> ErrorLogs { get; set; }
		public DbSet<CustomerFile> CustomerFiles { get; set; }
		public DbSet<UseCase> UseCases { get; set; }	
	}
	
}
