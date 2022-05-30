using System.Text.Json.Serialization;

namespace WhiteLabelWebshopS3.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        [JsonIgnore]
        public virtual Customer Customer { get; set; }
    }
}
