namespace WhiteLabelWebshopS3.Entities
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public Product Product { get; set; }    
        public Order Order { get; set; }
        /// <summary>
        /// how many products there are in the order
        /// </summary>
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }

    }
}
