using E_Bones.Domain.Entities;

namespace E_Bones.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> GetByIdAsync(Guid id);
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido> AddAsync(Pedido user);
        Task UpdateAsync(Pedido user, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
