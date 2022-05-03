namespace WhiteLabelWebshopS3.BAL.Models
{
    public class OrderDetailsModel
    {
        public int OrderDetailsId { get; set; }
        public ProductModel Product { get; set; }
        public OrderModel Order { get; set; }
        /// <summary>
        /// how many products there are in the order
        /// </summary>
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
    }
}
