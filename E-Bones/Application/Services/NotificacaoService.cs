using E_Bones.Application.Interfaces;
using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;

namespace E_Bones.Application.Services
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly INotificacaoRepository _notificacaoRepository;

        public NotificacaoService(INotificacaoRepository notificacaoRepository) 
        {
            _notificacaoRepository = notificacaoRepository;
        } 

        public Task<Notificacao> AddAsync(Notificacao user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Notificacao>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Notificacao> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Notificacao user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
