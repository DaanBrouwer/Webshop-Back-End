using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.API.DTOs;
using WhiteLabelWebshopS3.DAL;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController : Controller
    {
        private readonly StoreContext _context;

        public BasketController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await RetrieveBasket();

            if (basket == null) return NotFound();
            return ConvertToBasketDto(basket);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> AddItemToBasket(int ProductId, int quantity)
        {
            var basket = await RetrieveBasket();
            if (basket == null) basket = CreateBasket();
            var product = await _context.Products.FindAsync(ProductId);
            if(product == null) return NotFound();
            basket.AddItem(product, quantity);

            var result = await _context.SaveChangesAsync() > 0;
            if (result) return CreatedAtRoute("GetBasket", ConvertToBasketDto(basket));
            
            return BadRequest("problem saving item");
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteItemFromBasket(int ProductId, int quantity)
        {
            var basket = await RetrieveBasket();
            basket.RemoveItem(ProductId, quantity);
            await _context.SaveChangesAsync();
            var result = await _context.SaveChangesAsync() > 0;
            if (result) return Ok();
            return BadRequest("can't remove product");
        }

        private BasketDto ConvertToBasketDto(Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    ProductId = item.ProductId,
                    Name = item.product.Name,
                    Price = item.product.Price,
                    Brand = item.product.Brand,
                    Quantity = item.Quantity
                }).ToList()
            };
        }

        private Basket CreateBasket()
        {
            var buyerId = Guid.NewGuid().ToString();
            var cookie = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("buyerId", buyerId, cookie);
            var basket = new Basket { BuyerId = buyerId };
            _context.Basket.Add(basket);
            return basket;

        }
        private async Task<Basket>RetrieveBasket()
        {

            return await _context.Basket
                .Include(i => i.Items)
                .ThenInclude(p => p.product)
                .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);

        }

    }
}
