using AwsChallenge;
using AwsChallenge.Application.Interfaces;
using AwsChallenge.Models;
using AwsChallenge.Models.v1.Contacts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMvcCore();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapSwagger();
app.UseSwaggerUI();

AddEndpoints(app);

app.Run();

static void AddEndpoints(WebApplication app)
{
    const string preffix = "api";
    const string version = "v1";

    app.MapGet($"{preffix}/{version}/contatos", async (IContactService service) =>
    {
        var result = await service.GetAll();
        return result.AsApiResponse();
    });

    app.MapPost($"{preffix}/{version}/contatos", async (ContactRequest request, IContactService service) =>
    {
        await service.Insert(request.AsEntity());
        return Results.Ok();
    }
    ).Produces(StatusCodes.Status200OK);
}