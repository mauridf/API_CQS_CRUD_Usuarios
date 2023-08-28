using Microsoft.EntityFrameworkCore;

namespace API_CQS_CRUD_Usuarios.Data
{
    public class UsuarioContext : DbContext
    {
        public DbSet<UsuarioRequest> SupportRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioRequest>().HasKey(r => r.IdUsuario);
        }
    }
}
