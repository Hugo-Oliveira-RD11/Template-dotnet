namespace Crud.Models;

public class AppDbContext : DbContext
{
    AppDbContext(DbContextOptions<AppDbContext> op):base(op){}

    DbSet<Todo> Todos { get; set; }
}