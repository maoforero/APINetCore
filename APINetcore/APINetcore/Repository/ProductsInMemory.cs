using System;
using System.Collections;
using APINetcore.Models;

namespace APINetcore.Repository
{
	public class ProductsInMemory: IProductsInMemory
	{
		public readonly List<Models.Product> products = new()
		{
			new Models.Product {Id = 1, Name = "Chocorramo", Description = "Biscuit", Price = 2500.00, DateClose = DateTime.Now, SKU = "SKU001"},
			new Models.Product {Id = 2, Name = "Agua", Description = "Drink", Price = 1000.00, DateClose = DateTime.Now.AddHours(9), SKU = "SKU010"},
			new Models.Product {Id = 3, Name = "M&Ms", Description = "Candy", Price = 5200.50, DateClose = DateTime.Now.AddMonths(1), SKU = "SKU011"},
			new Models.Product {Id = 4, Name = "Tostacos", Description = "Chips", Price = 1600.20, DateClose = DateTime.Now, SKU = "SKU100"},
			new Models.Product {Id = 5, Name = "Detodito", Description = "Chips", Price = 800.99, DateClose = DateTime.Now.AddMonths(-4), SKU = "SKU101"},
		};

		public async Task<IEnumerable<Product>> GetAllProductsAsinc()
		{
			return await Task.FromResult(products);
		}

		public async Task<Product> GetProductAsinc(string SKU)
		{
			return await Task.FromResult(products.Where(p => p.SKU == SKU).SingleOrDefault());
		}

		public async Task AddProductAsinc(Product p)
		{
			products.Add(p);
			await Task.CompletedTask;
		}

        public async Task UpdateProductAsinc(Product p)
        {
			int matchingIndex = products.FindIndex(validProduct => validProduct.Id == p.Id);

			products[matchingIndex] = p;
			await Task.CompletedTask;
        }

        public async Task DeleteProductAsinc(string SKU)
        {
			int matchingIndex = products.FindIndex(validProduct => validProduct.SKU == SKU);
			products.RemoveAt(matchingIndex);

			await Task.CompletedTask;
        }


    }
}

