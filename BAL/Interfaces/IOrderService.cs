﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Models;

namespace WhiteLabelWebshopS3.BAL.Interfaces
{
    public interface IOrderService
    {
        Task<OrderModel> DeleteOrder(int id);
        Task<OrderModel> GetOrder(int id);
        Task<List<OrderModel>> Index();
        Task<OrderModel> NewOrder(OrderModel order);
        Task<List<OrderModel>> OrdersPerAccount(int id);
        Task<OrderModel> UpdateOrder(OrderModel order);
    }
}
