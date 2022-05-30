using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.DAL;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {

        private readonly StoreContext _context;
        public UserController(StoreContext context)
        {
            _context = context;
        }

        // POST: /api/User
        [HttpPost("Authentication")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Authenticate(UserDTO userDto)
        {
            var login = await _context.User.SingleOrDefaultAsync(x => x.Email == userDto.Email);
            if (login == null)
            {
                return BadRequest();
            }
            if (login.Password == userDto.Password)
            {
                return Ok();
            }
            else return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(UserDTO userDto)
        {
            if (await UserExists(userDto.Email))
            {
                return BadRequest("Email is already taken");
            }
            else
            {
                User newuser = new User
                {
                    Email = userDto.Email,
                    Password = userDto.Password
                };
                await _context.SaveChangesAsync();
                return Ok(newuser);
            }
        }
        private async Task<bool> UserExists(string email)
        {
            return await _context.User.AnyAsync(x => x.Email == email.ToLower());
        }

    }
}
