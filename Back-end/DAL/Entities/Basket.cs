﻿using System.Collections.Generic;
using System.Linq;

namespace WhiteLabelWebshopS3.DAL.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public string  BuyerId { get; set; }

        public List<BasketItem> Items { get; set; } = new();

        public void AddItem(Product product, int quantity)
        {
            if(Items.All(item => item.ProductId != product.Id))
            {
                Items.Add(new BasketItem { product = product, Quantity = quantity });
            }
            var existingitem = Items.FirstOrDefault(item => item.ProductId == Id);
            if(existingitem != null) existingitem.Quantity += quantity;
        }

        public void RemoveItem(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.ProductId == productId);
            if (item != null) item.Quantity -= quantity;
            if(item.Quantity == 0) Items.Remove(item);
            else return;
        }
    }

       
}
