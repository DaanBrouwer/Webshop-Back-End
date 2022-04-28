using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WhiteLabelWebshopS3.DTOs;

namespace WhiteLabelWebshopS3.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public Address Address { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }


    }
}
