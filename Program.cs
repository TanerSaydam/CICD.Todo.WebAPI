using CICD.Todo.WebAPI.Context;
using CICD.Todo.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");

app.MapGet("/getall", (ApplicationDbContext context) =>
{
    List<MyTodo> todos = context.Todos.ToList();

    return Results.Ok(todos);
});

app.MapGet("/create", (string work, ApplicationDbContext context) =>
{
    MyTodo myTodo = new()
    {
        Work = work,
    };
    context.Add(myTodo);
    context.SaveChanges();

    return Results.Ok(myTodo);
});

using (var scope = app.Services.CreateScope())
{
    var srv = scope.ServiceProvider;
    var context = srv.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
}

app.Run();
