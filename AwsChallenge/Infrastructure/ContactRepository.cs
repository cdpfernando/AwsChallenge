using AwsChallenge.Application.Interfaces;
using AwsChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwsChallenge.Infrastructure
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactDbContext _context;

        public ContactRepository(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task Insert(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
        }
    }
}
