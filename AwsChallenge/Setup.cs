namespace AwsChallenge
{
    public static class Setup
    {
        public static WebApplication GetWebApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDatabase(builder.Configuration);
            builder.Services.AddServices();

            var app = builder.Build();

            app.MapSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
