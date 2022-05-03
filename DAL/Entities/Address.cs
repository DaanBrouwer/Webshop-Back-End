using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhiteLabelWebshopS3.DAL.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int Streetnr { get; set; }

        public string PostalCode { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}
