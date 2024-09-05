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
using BCrypt.Net;

namespace AspProjekat.DataAccess
{
	public static class Seeder
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{

			using (var context = new FlowershopContext())
			{
				context.Database.EnsureCreated();
				
				if (context.Products.Any() || context.UseCases.Any() || context.Customers.Any())
				{
					return;
				}
				Random random = new Random();
				var UseCases = new List<UseCase>()
				{
					new UseCase
					{
						Id = 1,
						Name = "Get All Categories"
					},
					new UseCase
					{
						Id = 2,
						Name = "Create Category"
					},
					new UseCase
					{
						Id = 3,
						Name = "Get All Products"
					},
					new UseCase
					{
						Id = 4,
						Name = "Create Product"
					},
					new UseCase
					{
						Id = 5,
						Name = "Get All Suppliers"
					},
					new UseCase
					{
						Id = 6,
						Name = "Create Supplier"
					},
					new UseCase
					{
						Id = 7,
						Name = "Get All Customers"
					},
					new UseCase
					{
						Id = 8,
						Name = "Register Customer"
					},
					new UseCase
					{
						Id = 9,
						Name = "Get All Reviews"
					},
					new UseCase
					{
						Id = 10,
						Name = "Get All Orders"
					},
					new UseCase
					{
						Id = 11,
						Name = "Update Product"
					},
					new UseCase
					{
						Id = 12,
						Name = "Delete Category"
					},
					new UseCase
					{
						Id = 13,
						Name = "Create Order"
					},
					new UseCase
					{
						Id = 14,
						Name = "Get UseCase Log"
					}
				};
				context.UseCases.AddRange(UseCases);

				Customer c1 = new Customer
				{
					Name = "User",
					LastName = "User",
					Address = "User Address",
					City = "User City",
					Email = "user@gmail.com",
					Password = BCrypt.Net.BCrypt.HashPassword("test123"),
					State = "User state",
					UseCases = (ICollection<UseCase>)UseCases,
					Username = "user.username"
				};

				var customerFaker = new Faker<Customer>()
				.RuleFor(c => c.Name, f => f.Name.FirstName())
				.RuleFor(c => c.Username, f => f.Internet.UserName())
				.RuleFor(c => c.LastName, f => f.Name.LastName())
				.RuleFor(c => c.Email, f => f.Internet.Email())
				.RuleFor(c => c.Address, f => f.Address.StreetAddress())
				.RuleFor(c => c.City, f => f.Address.City())
				.RuleFor(c => c.State, f => f.Address.State())
				.RuleFor(c => c.ZipCode, f => f.Address.ZipCode())
				.RuleFor(c => c.Password, BCrypt.Net.BCrypt.HashString("test123"));
				var customers = customerFaker.Generate(75);
				customers.Add(c1);
				context.Customers.AddRange(customers);


				var categoryFaker = new Faker<Category>()
				.RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);
				var categories = categoryFaker.Generate(15);
				context.Categories.AddRange(categories);


				var supplierFaker = new Faker<Supplier>()
				.RuleFor(s => s.Name, f => f.Company.CompanyName())
				.RuleFor(s => s.SupplierEmail, f => f.Internet.Email())
				.RuleFor(s => s.SupplierPhone, f => f.Phone.PhoneNumber())
				.RuleFor(s => s.SupplierAddress, f => f.Address.StreetAddress())
				.RuleFor(s => s.SupplierCity, f => f.Address.City())
				.RuleFor(s => s.SupplierState, f => f.Address.State())
				.RuleFor(s => s.SupplierZipCode, f => f.Address.ZipCode());
				var suppliers = supplierFaker.Generate(15);
				context.Suppliers.AddRange(suppliers);

				var productFaker = new Faker<Product>()
					.RuleFor(s => s.Name, f => f.Commerce.ProductName())
					.RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
					.RuleFor(p => p.Price, f => f.Random.Double(30, 500))
					.RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl());
				var products = productFaker.Generate(100);

				for(var i = 0; i < products.Count; i++)
				{
						products[i].Supplier = suppliers[random.Next(1, suppliers.Count-1)];
						products[i].Categories.Add(categories[random.Next(1, categories.Count - 1)]);

				}
				context.Products.AddRange(products);

				var inventories = new List<Inventory>();
				for(var i = 0; i < products.Count;i++)
				{
					inventories.Add(new Inventory
					{
						Product = products[i],
						QuantityAvailable = random.Next(50, 500)
					});

				}
				context.Inventory.AddRange(inventories);


				var statuss = new List<string>()
				{
					{ "delivered" }, {"on hold"}, {"paid"}, {"pending"}
				};
				var orderFaker = new Faker<Order>()
					.RuleFor(p => p.Status, f => f.PickRandom(statuss))
					.RuleFor(p => p.PaymentMethod, f => f.PickRandom(new List<string>() { "mastercard", "paypal" }));

				var orders = orderFaker.Generate(100);
				for (var i = 0; i < orders.Count; i++)
				{
					orders[i].Customer = customers[random.Next(1, customers.Count - 1)];
					orders[i].CalculateTotalAmount();
				}
				context.Orders.AddRange(orders);


				var orderItemsFaker = new Faker<OrderItem>()
					.RuleFor(x => x.Quantity, f => f.Random.Int(5, 15));
				var orderItems = orderItemsFaker.Generate(100);
				for (int i = 0; i < orderItems.Count; i++)
				{
					orderItems[i].Product = products[random.Next(1, products.Count - 1)];
					orderItems[i].Order = orders[i];
				};
				context.OrderItems.AddRange(orderItems);

				var orderItemsDetailsFaker = new Faker<DeliveryDetails>()
					.RuleFor(x => x.DeliveryAddress, f => f.Address.StreetAddress())
					.RuleFor(x => x.DeliveryCity, f => f.Address.City())
					.RuleFor(x => x.DeliveryState, f => f.Address.State())
					.RuleFor(x => x.DeliveryStatus, "paid")
					.RuleFor(x => x.DeliveryDate, f => f.Date.Future(1))
					.RuleFor(x => x.DeliveryTime, f => f.Date.Future(1));
				var orderItemsDetails = orderItemsDetailsFaker.Generate(orders.Count);

				for(int i = 0;i < orders.Count;i++)
				{
					orderItemsDetails[i].Order = orders[i];
					orderItemsDetails[i].DeliveryZipCode = random.Next(11000, 11999).ToString();
				}
				context.DeliveryDetails.AddRange(orderItemsDetails);
				var revList = new List<Review>();
				for(int i = 0;i <= 50; i++)
				{
					revList.Add(new Review
					{
						Rating = random.Next(1, 5),
						Customer = customers[random.Next(1, customers.Count - 1)],
						Product = products[random.Next(1, products.Count - 1)],
						ReviewText = "Review " + i,
					});
				}
				context.Reviews.AddRange(revList);
				context.SaveChanges();

			}
		}

	}

}
