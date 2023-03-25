using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("AwsChallenge");

// Add services to the container.
builder.Services.AddDbContext<ContactDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvcCore();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.MapSwagger();
app.UseSwaggerUI();

app.MapGet("api/v1/contatos", async (ContactDbContext db) =>
    await db.Contacts.ToListAsync());

app.MapPost("api/v1/contatos", async (Contact contact, ContactDbContext db) =>
{
    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
    return Results.Ok();
}
).Produces(StatusCodes.Status200OK);

app.Run();


public class Contact
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("nome")]
    public string Name { get; set; }
    [JsonPropertyName("telefone")]
    public string PhoneNumber { get; set; }
}

class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options)
    : base(options) { }

    public DbSet<Contact> Contacts => Set<Contact>();
}