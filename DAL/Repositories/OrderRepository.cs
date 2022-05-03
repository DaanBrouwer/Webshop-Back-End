using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.Controllers;
using WhiteLabelWebshopS3.DAL;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.DAL.Repositories
{
    public class OrderRepository : IOrder
    {
        private readonly StoreContext _storecontext;

        public OrderRepository(StoreContext storecontext)
        {
            _storecontext = storecontext;
        }

        public Task<ActionResult> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<List<Order>>> Details(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<ActionResult<List<Order>>> Index()
        {
            throw new System.NotImplementedException();
        }
    }
}
