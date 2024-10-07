using E_Bones.Domain.Entities;
using E_Bones.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Bones.Infrastructure.Repositories
{
    public class PedidoRepository
    {
        private readonly DatabaseContext _context;

        public PedidoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Pedido> Add(Pedido entity)
        {
            if (entity != null)
            {
                await _context.Pedidos.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<List<Pedido>> GetAll()
        {
            return await _context.Pedidos.Where(p => p.DeletedAt == null).ToListAsync();
        }

        public async Task<Pedido?> GetById(Guid id)
        {
            return await _context.Pedidos.Where(p => p.DeletedAt == null).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Pedido?> Update(Pedido entity, Guid id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido != null && pedido.DeletedAt == null)
            {
                _context.Pedidos.Entry(pedido).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var pedidoExistente = await _context.Pedidos.FindAsync(id);

            if (pedidoExistente != null && pedidoExistente.DeletedAt == null)
            {
                await _context.Pedidos.Where(n => n.Id == id && n.DeletedAt == null)
                .ExecuteUpdateAsync(n => n.SetProperty(e => e.DeletedAt, DateTime.UtcNow));
            }

            return true;
        }
    }
}
