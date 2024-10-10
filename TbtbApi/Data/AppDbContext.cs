using Microsoft.EntityFrameworkCore;
using TbtbApi.Models;

namespace TbtbApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<UsuarioClass> Usuario { get; set; }
    }
}
