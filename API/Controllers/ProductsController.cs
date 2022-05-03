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
            //var result = await _products.Products.ToListAsync();

            return Ok(await _products.Index());

        }

        //api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            //var product = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

            return Ok(await _products.Get(id));
        }

        //api/products/id
        [HttpDelete("{id}")]
        //ToDo goede integratie of nog via Auth0 doen?
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            //var deleteProduct = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            //if (deleteProduct != null)
            //{
            //    _context.Products.Remove(deleteProduct);
            //    await _context.SaveChangesAsync();
            //    return (Ok(deleteProduct));
            //}
            //else
            //{
            //    return BadRequest();
            //}
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
            //_context.Products.Add(newProduct);
            //await _context.SaveChangesAsync();
            //return (Ok(newProduct));
            return Ok(await _products.NewProduct(newProduct));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(ProductDTO product)
        {
            //var updateproduct = await _context.Products.FindAsync(product.Id);

            //if (updateproduct != null)
            //{
            //    updateproduct = new Product
            //    {
            //        Id = product.Id,
            //        Name = product.Name,
            //        Description = product.Description,
            //        Price = product.Price,
            //        // ToDo Veranderen naar id van category
            //        //Category = product.Category,
            //        Brand = product.Brand,
            //        Stock = product.Stock
            //    };
            //    await _context.SaveChangesAsync();
            //    return Ok(updateproduct);
            //}
            //else
            //{
            //    return NotFound();
            //}
            //return Ok(await _products.UpdateProduct( ))
            return Ok();
        }
    }
}
