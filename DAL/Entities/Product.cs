using System.Collections.Generic;
using WhiteLabelWebshopS3.DTOs;

namespace WhiteLabelWebshopS3.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public long Price { get; set; }

        public ICollection<Category> Category { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

        public string Brand { get; set; }

        public int Stock { get; set; }

    }
}
