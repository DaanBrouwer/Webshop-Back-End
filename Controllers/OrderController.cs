using Microsoft.AspNetCore.Http;
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
    public class OrderController : Controller, IOrder
    {
        private readonly StoreContext _context;

        public OrderController(StoreContext context)
        {
            _context = context;
        }


        // GET: All Orders
        [HttpGet()]
        public async Task<ActionResult<List<Order>>> Index()
        {
            var orders = await _context.Order.Include(o => o.Customer).ThenInclude(x => x.Address).ToListAsync();

            return Ok(orders);
        }

        // GET: Orders based on 1 account
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Order>>> Details(int id)
        {
            var accountorders = await _context.Order.Include(x => x.OrderDetails)
                .ThenInclude(o => o.Product)
                .Where(u => u.Customer.Id == id).ToListAsync();

            return Ok(accountorders);
        }

        // ToDo maak get request voor 1 order info pagina

        // POST: OrderController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> NewOrder(OrderDTO order)
        //{
        //    // ToDo implement with all other factors like adress, customer and product tables
        //    Order neworder = new Order()
        //    {

        //    };

        //    return Ok(neworder);
        //}


        // GET: OrderController/Delete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteOrder = await _context.Order.SingleOrDefaultAsync(x => x.Id == id);
            if (deleteOrder != null)
            {
                await _context.SaveChangesAsync();
                return (Ok(deleteOrder));
            }
            else
            {
                return BadRequest();
            }

        }
    }
}
