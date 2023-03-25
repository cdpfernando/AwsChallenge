using AwsChallenge;

var app = Setup.GetWebApp(args);

app.AddContactsApi();

app.Run();

