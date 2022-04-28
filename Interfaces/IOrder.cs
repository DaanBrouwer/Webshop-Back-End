using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    public interface IOrder
    {
        Task<ActionResult> Delete(int id);
        Task<ActionResult<List<Order>>> Details(int id);
        Task<ActionResult<List<Order>>> Index();
    }
}