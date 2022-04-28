using System;
using System.Collections.Generic;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public List<Product> Product { get; set; }
        public DateTime Orderdate { get; set; }
    }
}
