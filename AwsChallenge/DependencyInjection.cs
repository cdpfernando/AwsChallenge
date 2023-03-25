using AwsChallenge.Application.Interfaces;
using AwsChallenge.Application.Services;
using AwsChallenge.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace AwsChallenge
{
    public static class DependencyInjection
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AwsChallenge");

            services.AddDbContext<ContactDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactService, ContactService>();
        }

    }
}
