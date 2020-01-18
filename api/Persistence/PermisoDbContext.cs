using Interview.Model;
using InterView.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class PermisoDbContext : DbContext
    {
        public DbSet<Permiso> permisos { get; set; }
        public DbSet<TipoPermiso> tipoPermisos { get; set; }

        public PermisoDbContext(DbContextOptions<PermisoDbContext> options)
            : base(options)
        { }
    }
}
