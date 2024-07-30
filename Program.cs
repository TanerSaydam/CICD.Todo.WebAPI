var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getall", () =>
{
    List<string> todos = new()
    {
        "Deneme 1",
        "Deneme 2",
        "Deneme 3"
    };

    return Results.Ok(todos);
});

app.Run();
