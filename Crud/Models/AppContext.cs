namespace Crud.Models;

public class AppContext : DbContext
{
    AppContext(DbContextOptions<AppContext> op):base(op){}

    DbSet<Todo> Todos { get; set; }
}