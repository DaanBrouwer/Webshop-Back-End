using System.Collections.Generic;

namespace WhiteLabelWebshopS3.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
    }

}
