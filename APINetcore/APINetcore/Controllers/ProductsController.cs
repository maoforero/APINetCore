using System;
using APINetcore.Repository;
using APINetcore.Models;
using Microsoft.AspNetCore.Mvc;

namespace APINetcore.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductsInMemory _productsInMemory;

        public ProductController()
        {
            _productsInMemory = new ProductsInMemory();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var listProducts = _productsInMemory.GetAllProducts();
            return listProducts;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productsInMemory.GetProduct(id);

            if (product is null) return NotFound();

            return product;
        }
    }
}

