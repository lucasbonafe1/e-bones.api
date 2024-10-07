using E_Bones.Domain.Entities;
using E_Bones.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Bones.Infrastructure.Repositories
{
    public class ProdutoRepository
    {
        private readonly DatabaseContext _context;

        public ProdutoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Produto> Add(Produto entity)
        {
            if (entity != null)
            {
                await _context.Produtos.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _context.Produtos.Where(p => p.DeletedAt == null).ToListAsync();
        }

        public async Task<Produto?> GetById(Guid id)
        {
            return await _context.Produtos.Where(p => p.DeletedAt == null).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Produto?> Update(Produto entity, Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto != null && produto.DeletedAt == null)
            {
                _context.Produtos.Entry(produto).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var produtoExistente = await _context.Produtos.FindAsync(id);

            if (produtoExistente != null && produtoExistente.DeletedAt == null)
            {
                await _context.Produtos.Where(n => n.Id == id && n.DeletedAt == null)
                .ExecuteUpdateAsync(n => n.SetProperty(e => e.DeletedAt, DateTime.UtcNow));
            }

            return true;
        }
    }
}
