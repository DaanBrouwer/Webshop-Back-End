using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WhiteLabelWebshopS3.DAL.Entities
{
    public class Customer
    {
        [ForeignKey("User")]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [JsonIgnore]
        public List<Order> Orders { get; set; }

        public User User { get; set; }
        [JsonIgnore]
        public virtual List<Address> Address { get; set; }

        public string PhoneNumber { get; set; } 

    }
}
