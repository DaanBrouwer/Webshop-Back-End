using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.Data;
using WhiteLabelWebshopS3.DTOs;
using WhiteLabelWebshopS3.DTOs.Models;
using WhiteLabelWebshopS3.Entities;


namespace WhiteLabelWebshopS3.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController : Controller, ICustomer
    {
        private readonly StoreContext _context;

        public CustomerController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _context.Customer.Include(c => c.User).ToListAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                return Ok(customer);
            }
            else return BadRequest();
        }

        [HttpGet]
        [Route("Account/{id}")]
        public async Task<ActionResult> GetAddressesAccount(int id)
        {


            var customer = await _context.Customer.Include(c => c.Address).FirstOrDefaultAsync(c => c.Id == id);

            return Ok(customer);
        }

        // ToDo checken wat ik wil opsturen en customer data + adres data?
        [HttpPost]
        public async Task<ActionResult> NewCustomer(CustomerDTO customerDTO)
        {
            //ToDo adres gelijk linken?
            var newcustomer = new Customer
            {
                Id = customerDTO.Id,
                FirstName = customerDTO.FirstName,
                LastName = customerDTO.LastName,
                //User = await _context.User.FindAsync(customerDTO.Id),
                PhoneNumber = customerDTO.PhoneNumber
            };
            _context.Customer.Add(newcustomer);
            await _context.SaveChangesAsync();
            return Ok(newcustomer);
        }

        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer(CustomerDTO customerDTO)
        {
            var updatedcustomer = await _context.Customer.FindAsync(customerDTO.Id);
            if (updatedcustomer != null)
            {
                Customer customer = new Customer
                {
                    Id = updatedcustomer.Id,
                    FirstName = customerDTO.FirstName,
                    LastName = customerDTO.LastName,
                    PhoneNumber = customerDTO.PhoneNumber

                };
                _context.Entry(updatedcustomer).CurrentValues.SetValues(customer);
                //_context.Customer.Update(customer);
                await _context.SaveChangesAsync();
                return Ok(customer);
            }
            return BadRequest();
        }

    }
}
