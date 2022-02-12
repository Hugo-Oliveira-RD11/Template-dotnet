namespace Crud.Models;

public class AppDbContext : DbContext
{
    AppDbContext(DbContextOptions<AppDbContext> op):base(op){}

    public DbSet<Todo> Todos { get; set; }
}