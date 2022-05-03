﻿using System.Collections.Generic;

namespace WhiteLabelWebshopS3.BAL.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ProductModel> Products { get; set; }
    }
}