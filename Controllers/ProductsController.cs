using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WhiteLabelWebshopS3.Data;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly StoreContext _context;

        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        // GET: Products
        [HttpGet()]
        public async Task<ActionResult<List<Product>>> Index()
        {
            return await _context.Products.ToListAsync();

        }

        //api/products/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int? id)
        {
            return await _context.Products.SingleOrDefaultAsync(x => x.Id == id);

        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
