using System.Text.Json.Serialization;

namespace AwsChallenge.Domain.Entities
{
    public class Contact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
