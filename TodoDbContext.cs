using System.Data;
using Microsoft.EntityFrameworkCore;

public class ToDdoDbContext : DbContext
{
    public ToDdoDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
}