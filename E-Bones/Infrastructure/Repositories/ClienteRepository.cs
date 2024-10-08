using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;
using E_Bones.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Bones.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseContext _context;

        public ClienteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Add(Cliente entity)
        {
            entity.DataDeCriacao = DateTime.UtcNow;

            if(entity != null)
            {
                await _context.Clientes.AddAsync(entity);
                await _context.SaveChangesAsync(); 
            } 

            return entity;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.Where(c => c.DeletedAt == null).Include(c => c.Pedidos).ToListAsync();
        }

        public async Task<Cliente?> GetById(Guid id)
        {
            return await _context.Clientes.Where(c => c.DeletedAt == null).Include(c => c.Pedidos).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cliente?> Update(Cliente? entity, Guid id)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);

            if (clienteExistente != null && clienteExistente.DeletedAt == null)
            {
                _context.Clientes.Entry(clienteExistente).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            } 

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);

            if (clienteExistente != null && clienteExistente.DeletedAt == null)
            {
                await _context.Clientes.Where(c => c.Id == id && c.DeletedAt == null)
                .ExecuteUpdateAsync(c => c.SetProperty(e => e.DeletedAt, DateTime.UtcNow));
            }

            return true;
        }
    }
}
