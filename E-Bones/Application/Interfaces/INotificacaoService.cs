using E_Bones.Domain.Entities;

namespace E_Bones.Application.Interfaces
{
    public interface INotificacaoService
    {
        Task<Notificacao> GetByIdAsync(Guid id);
        Task<IEnumerable<Notificacao>> GetAllAsync();
        Task<Notificacao> AddAsync(Notificacao user);
        Task UpdateAsync(Notificacao user, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
