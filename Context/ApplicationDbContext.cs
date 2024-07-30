using CICD.Todo.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CICD.Todo.WebAPI.Context;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<MyTodo> Todos { get; set; }
}
