using AwsChallenge.Domain.Entities;
using AwsChallenge.Models.v1.Contacts;

namespace AwsChallenge.Models
{
    public static class Mapper
    {
        public static Contact AsEntity(this ContactRequest request) => new Contact { Name = request.Name, PhoneNumber = request.PhoneNumber };
        public static ContactResponse AsApiResponse(this Contact entity) => new ContactResponse { Id = entity.Id, PhoneNumber = entity.PhoneNumber, Name = entity.Name };
        public static IEnumerable<ContactResponse> AsApiResponse(this IEnumerable<Contact> entity) => entity.Select(x => x.AsApiResponse());
    }
}
