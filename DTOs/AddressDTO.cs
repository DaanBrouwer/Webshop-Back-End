namespace WhiteLabelWebshopS3.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int Streetnr { get; set; }

        public string PostalCode { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
         
        public int CustomerID { get; set; }
    }
}
