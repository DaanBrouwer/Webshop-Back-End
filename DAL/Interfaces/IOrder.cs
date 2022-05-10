using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiteLabelWebshopS3.BAL.Models;
using WhiteLabelWebshopS3.DAL.Entities;

namespace WhiteLabelWebshopS3.BAL.Interfaces
{
    public interface IOrder
    {
        Task<OrderModel> DeleteOrder(int id);
        Task<OrderModel> GetOrder(int id);
        Task<List<OrderModel>> Index();
        Task<OrderModel> NewOrder(OrderModel order);
        Task<List<OrderModel>> OrdersPerAccount(int id);
        Task<OrderModel> UpdateOrder(OrderModel order);
    }
}