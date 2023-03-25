using AwsChallenge.Application.Interfaces;
using AwsChallenge.Models;
using AwsChallenge.Models.v1.Contacts;

namespace AwsChallenge.Apis
{
    public static class ContactsApi
    {
        public static void AddContactsApi(this WebApplication app)
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
    }
}
