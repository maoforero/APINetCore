using System;
using APINetcore.Repository;
using APINetcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace APINetcore.Controllers
{
	[Route("products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly ProductsInMemory productsInMemory;

		public ProductsController()
		{
			productsInMemory = new ProductsInMemory();
		}

		[HttpGet]
		public IEnumerable<Product> GetAllProducts()
		{
			var productList = productsInMemory.GetAllProducts();
			return productList;
		}

		[HttpGet("{id}")]
		public ActionResult<Product> GetProduct(int id)
		{
			var product = productsInMemory.GetProduct(id);

			if(product is null) return NotFound();

			return product;
		}
	}
}

