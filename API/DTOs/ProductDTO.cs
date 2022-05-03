namespace WhiteLabelWebshopS3.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public long Price { get; set; }

        public int CategoryId { get; set; }

        public string Brand { get; set; }

        public int Stock { get; set; }

    }
}
