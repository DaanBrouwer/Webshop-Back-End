using System.Collections.Generic;

namespace WhiteLabelWebshopS3.BAL.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<OrderModel> Orders { get; set; }

        public UserModel User { get; set; }

        public ICollection<AddressModel> Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
