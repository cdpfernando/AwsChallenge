using AwsChallenge.Domain.Entities;

namespace AwsChallenge.Application.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAll();
        Task Insert(Contact contact);
    }
}
