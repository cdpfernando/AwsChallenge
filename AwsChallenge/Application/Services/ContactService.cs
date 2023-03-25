using AwsChallenge.Application.Interfaces;
using AwsChallenge.Domain.Entities;

namespace AwsChallenge.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _contactRepository.GetAll();
        }

        public Task Insert(Contact contact)
        {
            return _contactRepository.Insert(contact);
        }
    }
}
