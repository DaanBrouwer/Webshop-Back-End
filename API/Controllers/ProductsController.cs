using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLabelWebshopS3.DAL;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.DAL.Entities;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.BAL.Models;

namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _products;

        public ProductsController(IProductService products)
        {
            _products = products;
        }

        // GET:  //api/products
        [HttpGet()]
        public async Task<ActionResult<List<Product>>> Index()
        {
            return Ok(await _products.Index());
        }

        //api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            return Ok(await _products.Get(id));
        }

        //api/products/id
        [HttpDelete("{id}")]
        //ToDo goede integratie of nog via Auth0 doen?
        public async Task<ActionResult> Delete(int id)
        {

            return Ok(await _products.Delete(id));
        }

        [HttpPost]
        public async Task<ActionResult> NewProduct(ProductDTO product)
        {
            ProductModel newProduct = new ProductModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                // ToDo Veranderen naar id van category
                //Category = product.Category,
                Brand = product.Brand,
                Stock = product.Stock
            };

            return Ok(await _products.NewProduct(newProduct));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(int id, ProductDTO product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            return Ok(await _products.UpdateProduct(new ProductModel
            {
                Id = id,
                Name = product.Name,
                Description = product.Description,
                Price= product.Price,
                // ToDo Veranderen naar id van category
                //Category = product.Category,
                Brand = product.Brand,
                Stock = product.Stock

            }));
        }
    }
}
