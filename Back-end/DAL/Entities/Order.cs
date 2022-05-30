using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WhiteLabelWebshopS3.DTOs;

namespace WhiteLabelWebshopS3.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Orderdate { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public Address Address { get; set; }

        public List<OrderDetails> OrderDetails { get; set; }


    }
}
