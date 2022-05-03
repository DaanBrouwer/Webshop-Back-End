using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.BAL.Interfaces
{
    public interface ICategory
    {
        Task<ActionResult<Category>> AddCategory(CategoryDTO categoryDTO);
        Task<ActionResult<List<Category>>> Categories();
        Task<ActionResult<Category>> Category(int id);
        Task<ActionResult> DeleteCategory(int id);
        Task<ActionResult> UpdateCategory(CategoryDTO categoryDTO);
    }
}