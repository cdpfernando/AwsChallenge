using AwsChallenge.Domain.Entities;

namespace AwsChallenge.Application.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task Insert(Contact contact);
    }
}
