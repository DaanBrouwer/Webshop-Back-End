using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLabelWebshopS3.Data;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : Controller, IProducts
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // GET:  //api/products
        [HttpGet()]
        public async Task<ActionResult<List<Product>>> Index()
        {
            var result = await _context.Products.ToListAsync();

            return Ok(result);

        }

        //api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int? id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

            return Ok(product);
        }

        //api/products/id
        [HttpDelete("{id}")]
        //ToDo goede integratie of nog via Auth0 doen?
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
                await _context.SaveChangesAsync();
                return (Ok(deleteProduct));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<ActionResult> NewProduct(ProductDTO product)
        {
            Product newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                // ToDo Veranderen naar id van category
                //Category = product.Category,
                Brand = product.Brand,
                Stock = product.Stock
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return (Ok(newProduct));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductDTO product)
        {
            var updateproduct = await _context.Products.FindAsync(product.Id);

            if (updateproduct != null)
            {
                updateproduct = new Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    // ToDo Veranderen naar id van category
                    //Category = product.Category,
                    Brand = product.Brand,
                    Stock = product.Stock
                };
                await _context.SaveChangesAsync();
                return Ok(updateproduct);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
