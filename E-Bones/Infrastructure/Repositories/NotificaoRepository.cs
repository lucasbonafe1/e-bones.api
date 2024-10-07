﻿using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;
using E_Bones.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Bones.Infrastructure.Repositories
{
    public class NotificaoRepository : INotificacaoRepository
    {
        private readonly DatabaseContext _context;

        public NotificaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<Notificacao> Add(Notificacao entity)
        {
            if (entity != null)
            {
                await _context.Notificacoes.AddAsync(entity);
                await _context.SaveChangesAsync();
            }

            return entity;
        }

        public async Task<List<Notificacao>> GetAll()
        {
            return await _context.Notificacoes.Where(n => n.DeletedAt == null).ToListAsync();
        }

        public async Task<Notificacao?> GetById(Guid id)
        {
            return await _context.Notificacoes.Where(n => n.DeletedAt == null).Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Notificacao?> Update(Notificacao entity, Guid id)
        {
            var notificacao = await _context.Clientes.FindAsync(id);

            if (notificacao != null && notificacao.DeletedAt == null)
            {
                _context.Clientes.Entry(notificacao).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            } 

            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var clienteExistente = await _context.Clientes.FindAsync(id);

            if (clienteExistente != null && clienteExistente.DeletedAt == null)
            {
                await _context.Clientes.Where(n => n.Id == id && n.DeletedAt == null)
                .ExecuteUpdateAsync(n => n.SetProperty(e => e.DeletedAt, DateTime.UtcNow));
            }

            return true;
        }
    }
}
