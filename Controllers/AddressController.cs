using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.Data;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AddressController : Controller, IAddress
    {
        private readonly StoreContext _context;
        public AddressController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAddresses()
        {
            var alladdresses = await _context.Address.ToListAsync();
            return Ok(alladdresses);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetSingleAddress(int id)
        {

            var address = await _context.Address.FindAsync(id);
            if (address != null)
            {
                return Ok(address);
            }
            return BadRequest();
        }


        //ToDo returnen van entity object cycle, address entity meegeven en converten naar dto return? of dto meegeven en zelfde dto weer returnen?
        [HttpPost]
        public async Task<ActionResult> NewAddress(AddressDTO addressDTO)
        {
            if (addressDTO != null)
            {
                var Address = new Address
                {
                    StreetName = addressDTO.StreetName,
                    City = addressDTO.City,
                    Streetnr = addressDTO.Streetnr,
                    PostalCode = addressDTO.PostalCode,
                    Country = addressDTO.Country,
                    Customer = await _context.Customer.FirstOrDefaultAsync(x => x.Id == addressDTO.CustomerID)
                };
                _context.Address.Add(Address);
                await _context.SaveChangesAsync();
                return Ok(addressDTO);

            }
            else return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var deleteaddress = await _context.Address.FindAsync(id);
            if (deleteaddress != null)
            {
                _context.Address.Remove(deleteaddress);
                await _context.SaveChangesAsync();
                return Ok(deleteaddress);

            }
            else return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAddress(AddressDTO addressDTO)
        {
            var findaddress = await _context.Address.FindAsync(addressDTO.Id);
            if (findaddress != null)
            {
                Address updatedaddress = new Address
                {
                    Id = addressDTO.Id,
                    StreetName = addressDTO.StreetName,
                    Streetnr = addressDTO.Streetnr,
                    PostalCode = addressDTO.PostalCode,
                    City = addressDTO.City,
                    Country = addressDTO.Country,
                    Customer = await _context.Customer.FindAsync(addressDTO.CustomerID)
                };
                _context.Entry(findaddress).CurrentValues.SetValues(updatedaddress);
                await _context.SaveChangesAsync();
                return Ok(updatedaddress);
            }
            else return BadRequest();
        }
    }
}
