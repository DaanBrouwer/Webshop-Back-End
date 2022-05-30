using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Interfaces;
using WhiteLabelWebshopS3.BAL.Models;

namespace WhiteLabelWebshopS3.BAL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrder _order;

        public OrderService(IOrder order)
        {
            _order = order;
        }

        public async Task<List<OrderModel>> Index()
        {
            return await _order.Index();
        }

        public async Task<List<OrderModel>> OrdersPerAccount(int id)
        {
            return await _order.OrdersPerAccount(id);
        }

        public async Task<OrderModel> GetOrder(int id)
        {
            return await GetOrder(id);
        }

        public async Task<OrderModel> NewOrder(OrderModel order)
        {
            return await _order.NewOrder(order);
        }

        public async Task<OrderModel> UpdateOrder(OrderModel order)
        {
            return await _order.UpdateOrder(order);   
        }

        public async Task<OrderModel> DeleteOrder(int id)
        {
            return await _order.DeleteOrder(id);
        }
    }
}
