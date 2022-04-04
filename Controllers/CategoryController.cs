using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.Data;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class CategoryController : Controller
    {
        private readonly StoreContext _context;
        public CategoryController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> Categories()
        {
            return await _context.Categories.ToListAsync();

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> Category(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
    }
}
