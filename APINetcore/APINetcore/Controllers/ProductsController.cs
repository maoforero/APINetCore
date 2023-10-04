using System;
using APINetcore.Repository;
using APINetcore.Models;
using Microsoft.AspNetCore.Mvc;
using APINetcore.DTO;
using Utils;

namespace APINetcore.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsInMemory _productsInMemory;

        public ProductController(IProductsInMemory productsInMemory)
        {
            this._productsInMemory = productsInMemory;
        }

        [HttpGet]
        public IEnumerable<ProductDTO> GetAllProducts()
        {
            var listProducts = _productsInMemory.GetAllProducts().Select(p => p.TransformToDTO());
            return listProducts;
        }

        [HttpGet("{code}")]
        public ActionResult<ProductDTO> GetProduct(string code)
        {
            var product = _productsInMemory.GetProduct(code).TransformToDTO();

            if (product is null) return NotFound();

            return product;
        }

        [HttpPost]
        public ActionResult<ProductDTO> AddProduct(ProductDTO p)
        {
            Product product = new Product
            {
                Id = _productsInMemory.GetAllProducts().Max(x => x.Id) + 1,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                SKU = p.SKU,
                DateClose = DateTime.Now,
            };

            _productsInMemory.AddProduct(product);

            return product.TransformToDTO();
        }


        [HttpPut]
        public ActionResult<ProductDTO> UpdateProduct(string code , ProductUpdatedDTO p)
        {
            Product validProduct = _productsInMemory.GetProduct(code);

            if(validProduct is null)
            {
                return NotFound();
            }

            validProduct.Name = p.Name;
            validProduct.Description = p.Description;
            validProduct.Price = p.Price;

            return validProduct.TransformToDTO();

        }
    }
}

