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

    }
}
