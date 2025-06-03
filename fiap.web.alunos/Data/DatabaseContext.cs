using fiap.web.alunos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace fiap.web.alunos.Data
{
    public class DatabaseContext : DbContext

    {
        public virtual DbSet<ClienteModel> Clientes { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClienteModel>(entity => {
                entity.ToTable("Clientes");
                entity.HasKey(e => e.IdCliente);
                entity.Property(e => e.Nome).IsRequired();
                entity.HasIndex(e => e.Cpf).IsUnique();
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
