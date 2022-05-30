
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiteLabelWebshopS3.DAL.Entities
{
    [Table("BasketItems")]
    public class BasketItem
    {
        public int id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }

        public int BasketId { get; set; }
        public Basket basket { get; set; }

    }
}
