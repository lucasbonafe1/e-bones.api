using E_Bones.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Bones.Infrastructure.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TarefaDeProcessamento> TarefaDeProcessamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>().ToTable("clientes");
            modelBuilder.Entity<Notificacao>().ToTable("notificacao");
            modelBuilder.Entity<Pedido>().ToTable("pedidos");
            modelBuilder.Entity<Produto>().ToTable("produtos");
            modelBuilder.Entity<TarefaDeProcessamento>().ToTable("task_processamento");

            // ------- Alteração de coluna deleted_at (agora relacionada a um atributo) --

            modelBuilder.Entity<Cliente>()
                .ToTable("clientes")
                .Property(p => p.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamptz");

            modelBuilder.Entity<Notificacao>()
                .ToTable("notificacao")
                .Property(p => p.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamptz");

            modelBuilder.Entity<Pedido>()
                .ToTable("pedidos")
                .Property(p => p.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamptz");

            modelBuilder.Entity<Produto>()
                .ToTable("produtos")
                .Property(p => p.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamptz");

            modelBuilder.Entity<TarefaDeProcessamento>()
                .ToTable("task_processamento")
                .Property(p => p.DeletedAt)
                .HasColumnName("deleted_at")
                .HasColumnType("timestamptz");
        }
    }
}
