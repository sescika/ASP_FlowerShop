using AspProjekat.Domain;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;
using static System.Net.Mime.MediaTypeNames;

namespace AspProjekat.DataAccess
{
	public static class Seeder
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{

			using (var context = new FlowershopContext())
			{
				context.Database.EnsureCreated();

				if (context.Products.Any())
				{
					return;
				}

				var customerFaker = new Faker<Customer>()
				.RuleFor(c => c.Name, f => f.Name.FirstName())	
				.RuleFor(c => c.Username, f => f.Internet.UserName())
				.RuleFor(c => c.LastName, f => f.Name.LastName())
				.RuleFor(c => c.Email, f => f.Internet.Email())
				.RuleFor(c => c.Address, f => f.Address.StreetAddress())
				.RuleFor(c => c.City, f => f.Address.City())
				.RuleFor(c => c.State, f => f.Address.State())
				.RuleFor(c => c.ZipCode, f => f.Address.ZipCode());
				var customers = customerFaker.Generate(50);

				var categoryFaker = new Faker<Category>()
				.RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);
				var categories = categoryFaker.Generate(10);

				var supplierFaker = new Faker<Supplier>()
				.RuleFor(s => s.Name, f => f.Company.CompanyName())
				.RuleFor(s => s.SupplierEmail, f => f.Internet.Email())
				.RuleFor(s => s.SupplierPhone, f => f.Phone.PhoneNumber())
				.RuleFor(s => s.SupplierAddress, f => f.Address.StreetAddress())
				.RuleFor(s => s.SupplierCity, f => f.Address.City())
				.RuleFor(s => s.SupplierState, f => f.Address.State())
				.RuleFor(s => s.SupplierZipCode, f => f.Address.ZipCode());
				var suppliers = supplierFaker.Generate(10);

				var productFaker = new Faker<Product>()
					.RuleFor(s => s.Name, f => f.Commerce.ProductName())
					.RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
					.RuleFor(p => p.Price, f => f.Random.Double())
					.RuleFor(p => p.Categories, f => categories)
					.RuleFor(p => p.SupplierId, f => f.PickRandom(suppliers).Id)
					.RuleFor(p => p.ImageUrl, f => f.Image.LoremPixelUrl());
				var products = productFaker.Generate(50);

				var inventoryFaker = new Faker<Inventory>()
					.RuleFor(i => i.ProductId, f => f.PickRandom(products).Id)
					.RuleFor(i => i.QuantityAvailable, f => f.Random.Int(0, 100));
				var inventories = inventoryFaker.Generate(100);

				var reviewFaker = new Faker<Review>()
					.RuleFor(x => x.CustomerId, f => f.PickRandom(customers).Id)
					.RuleFor(x => x.ProductId, f => f.PickRandom(products).Id)
					.RuleFor(x => x.ReviewText, f => f.Lorem.Text())
					.RuleFor(x => x.Rating, f => f.Random.Int(1, 5));
				var reviews = reviewFaker.Generate(100);

				//var deliveryDetailsFaker = new Faker<DeliveryDetails>()
				//	.RuleFor(x => x)

				//var orderFaker = new Faker<Order>()
				//	.RuleFor(x => x.CustomerId, f => f.PickRandom(customers).Id)
				//	.RuleFor(x => x.)

				context.Customers.AddRange(customers);
				context.Categories.AddRange(categories);
				context.Suppliers.AddRange(suppliers);
				context.SaveChanges();
			}
		}

	}

}
