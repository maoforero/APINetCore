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
        public async Task <IEnumerable<ProductDTO>> GetAllProducts()
        {
            var listProducts = (await _productsInMemory.GetAllProductsAsinc()).Select(p => p.TransformToDTO());
            return listProducts;
        }

        [HttpGet("{code}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(string code)
        {
            var product = (await _productsInMemory.GetProductAsinc(code)).TransformToDTO();

            if (product is null) return NotFound();

            return product;
        }

        [HttpPost]
        public async Task <ActionResult<ProductDTO>> AddProduct(ProductDTO p)
        {
            Product product = new Product
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                SKU = p.SKU,
                DateClose = DateTime.Now,
            };

            await _productsInMemory.AddProductAsinc(product);

            return product.TransformToDTO();
        }


        [HttpPut]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(string code , ProductUpdatedDTO p)
        {
            Product validProduct = await _productsInMemory.GetProductAsinc(code);

            if(validProduct is null)
            {
                return NotFound();
            }

            validProduct.Name = p.Name;
            validProduct.Description = p.Description;
            validProduct.Price = p.Price;

            _productsInMemory.UpdateProductAsinc(validProduct);

            return validProduct.TransformToDTO();

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(string SKU)
        {
            Product product = await _productsInMemory.GetProductAsinc(SKU);
            if (product is null) return NotFound();

            _productsInMemory.DeleteProductAsinc(product.SKU);

            return NoContent();
        }
    }
}

