using System;
using APINetcore.Models;

namespace APINetcore.Repository
{
	public interface IProductsInMemory
	{
        IEnumerable<Product> GetAllProducts();
        Product GetProduct(string SKU);
        void AddProduct(Product p);
        void UpdateProduct(Product p);
    }
}

