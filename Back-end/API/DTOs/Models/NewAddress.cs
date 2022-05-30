namespace WhiteLabelWebshopS3.DTOs.Models
{
    public class NewAddress
    {
        public string StreetName { get; set; }
        public int Streetnr { get; set; }

        public string PostalCode { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
    }
}
