using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.Data;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : Controller, ICategory
    {
        private readonly StoreContext _context;
        public CategoryController(StoreContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Get All Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Categories()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories);
        }
        /// <summary>
        /// Get specific category which shows list of items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Category>> Category(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                Name = categoryDTO.Name,

            };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var deletecategory = await _context.Categories.FindAsync(id);
            if (deletecategory != null)
            {
                _context.Categories.Remove(deletecategory);
                await _context.SaveChangesAsync();
                return Ok(deletecategory);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategory(CategoryDTO categoryDTO)
        {
            var updatecategory = await _context.Categories.FindAsync(categoryDTO.Id);
            //var updatecategory = await _context.Categories.AsNoTracking().Where(x => x.Id.Equals(categoryDTO.Id)).FirstOrDefaultAsync();
            if (updatecategory != null)
            {
                Category category = new Category
                {
                    Id = updatecategory.Id,
                    Name = categoryDTO.Name,
                };
                _context.Entry(updatecategory).CurrentValues.SetValues(category);
                //_context.Categories.Update(category);  
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            else return BadRequest();
        }




    }
}
