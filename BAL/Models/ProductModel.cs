using System.Collections.Generic;

namespace WhiteLabelWebshopS3.BAL.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public long Price { get; set; }

        public ICollection<CategoryModel> Category { get; set; }
        public ICollection<OrderDetailsModel> OrderDetails { get; set; }

        public string Brand { get; set; }

        public int Stock { get; set; }
    }
}
