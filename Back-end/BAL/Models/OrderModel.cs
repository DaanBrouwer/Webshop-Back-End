using System;
using System.Collections.Generic;

namespace WhiteLabelWebshopS3.BAL.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        public CustomerModel Customer { get; set; }
        public AddressModel Address { get; set; }

        public ICollection<OrderDetailsModel> OrderDetails { get; set; }

    }
}
