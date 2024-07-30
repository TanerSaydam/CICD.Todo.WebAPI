var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//Note
app.MapGet("/", () => "Hello World!");

app.Run();
