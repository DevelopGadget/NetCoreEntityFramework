using Microsoft.EntityFrameworkCore;

namespace NetCoreSql.Models
{
  public class DbContextApp : DbContext
  {
    public DbContextApp(DbContextOptions<DbContextApp> App) : base(App){}
    public DbSet<Usuario> Usuarios { get; set; }
  }
}