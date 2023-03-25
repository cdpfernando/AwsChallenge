using AwsChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AwsChallenge.Infrastructure
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options)
        : base(options) { }

        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
