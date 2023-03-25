using System.Text.Json.Serialization;

namespace AwsChallenge.Models.v1.Contacts
{
    public class ContactRequest
    { 
        [JsonPropertyName("nome")]
        public string Name { get; set; }
        [JsonPropertyName("telefone")]
        public string PhoneNumber { get; set; }
    }
}
