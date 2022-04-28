﻿using System.Collections.Generic;
using WhiteLabelWebshopS3.Entities;

namespace WhiteLabelWebshopS3.DTOs.Models
{
    public class CustomerAddresses
    {
        public int Id { get; set; }
        public ICollection<Address> Address { get; set; }

    }
}
