using System;
using System.Collections;
using APINetcore.Models;

namespace APINetcore.Repository
{
	public interface IProductsInMemory
	{
        Task<IEnumerable<Product>> GetAllProductsAsinc();
        Task<Product> GetProductAsinc(string SKU);
        Task AddProductAsinc(Product p);
        Task UpdateProductAsinc(Product p);
        Task DeleteProductAsinc(string SKU);
    }
}

