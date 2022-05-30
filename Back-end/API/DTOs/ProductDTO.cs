using System.Collections.Generic;

namespace WhiteLabelWebshopS3.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public long Price { get; set; }

        public List<CategoryDTO> categories { get; set; }

        public string Brand { get; set; }

        public int Stock { get; set; }

    }
}
