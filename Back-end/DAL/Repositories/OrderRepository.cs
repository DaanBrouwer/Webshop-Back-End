using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.BAL.Models;
using WhiteLabelWebshopS3.Controllers;
using WhiteLabelWebshopS3.DAL;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.DAL.Repositories
{
    public class OrderRepository 
    {
        private readonly StoreContext _storecontext;

        public OrderRepository(StoreContext storecontext)
        {
            _storecontext = storecontext;
        }

        public async Task<OrderModel> DeleteOrder(int id)
        {
            var entity = _storecontext.Remove(new Order { Id = id}).Entity;
            await _storecontext.SaveChangesAsync();

            return new OrderModel
            {
                Id = entity.Id
            };

        }

    //    public async Task<OrderModel> GetOrder(int id)
    //    {

    //        var order = _storecontext.Order.Select(order => new OrderModel
    //        {
    //            Id = order.Id,
    //            Orderdate = order.Orderdate,
    //            Customer = _storecontext.Order.Where(x => x.Customer == id).FirstOrDefault()
    //            Address = null,
    //            //Address = order.Address.Select(address => new AddressModel
    //            //{
    //            //    StreetName = address.StreetName,
    //            //    Streetnr = address.Streetnr,
    //            //    PostalCode = address.PostalCode,
    //            //    City = address.City,
    //            //    Country = address.Country,
    //            //}),
    //            OrderDetails = null
    //        }).SingleorDefaultasync(x => x.Id == id);

    //        return await order;
    //    }

    //    public Task<List<OrderModel>> Index()
    //    {
    //        var orders = _storecontext.Order
    //            .Select(order => new OrderModel
    //            {
    //                Id = order.Id,
    //                Orderdate = order.Orderdate,
    //                Customer = order.Customer.Select(c => new CustomerModel
    //                {
    //                    FirstName = c.FirstName,
    //                    LastName = c.LastName,
    //                }),
    //        });
    //    }

    //    public Task<OrderModel> NewOrder(OrderModel order)
    //    {
    //        throw new System.NotImplementedException();
    //    }

    //    public async Task<List<OrderModel>> OrdersPerAccount(int id)
    //    {
    //        var accountorders = await _storecontext.Order.Include(x => x.OrderDetails)
    //            .ThenInclude(o => o.Product)
    //.Where(u => u.Customer.Id == id).ToListAsync();
    //    }

    //    public Task<OrderModel> UpdateOrder(OrderModel order)
    //    {
    //        throw new System.NotImplementedException();
    //    }
    }
}
