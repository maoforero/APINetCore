using System;
using APINetcore.Models;

namespace APINetcore.Repository
{
	public class ProductsInMemory
	{
		public readonly List<Models.Product> products = new()
		{
			new Models.Product {Id = 1, Name = "Chocorramo", Description = "Biscuit", Price = 2500.00, DateClose = DateTime.Now},
			new Models.Product {Id = 2, Name = "Agua", Description = "Drink", Price = 1000.00, DateClose = DateTime.Now.AddHours(9)},
			new Models.Product {Id = 3, Name = "M&Ms", Description = "Candy", Price = 5200.50, DateClose = DateTime.Now.AddMonths(1)},
			new Models.Product {Id = 4, Name = "Tostacos", Description = "Chips", Price = 1600.20, DateClose = DateTime.Now},
			new Models.Product {Id = 5, Name = "Detodito", Description = "Chips", Price = 800.99, DateClose = DateTime.Now.AddMonths(-4)},
		};

		public IEnumerable<Product> GetAllProducts()
		{
			return products;
		}

		public Product GetProduct(int id)
		{
			return products.Where(p => p.Id == id).SingleOrDefault();
		}
	}
}

