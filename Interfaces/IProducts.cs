using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    public interface IProducts
    {
        Task<ActionResult> Delete(int id);
        Task<ActionResult<Product>> Get(int? id);
        Task<ActionResult<List<Product>>> Index();
        Task<ActionResult> NewProduct(ProductDTO product);
        Task<IActionResult> UpdateProduct(ProductDTO product);
    }
}