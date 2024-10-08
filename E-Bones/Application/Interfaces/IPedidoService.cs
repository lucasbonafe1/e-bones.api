using E_Bones.Application.Dtos.Pedidos;
using E_Bones.Domain.Entities;

namespace E_Bones.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<PedidoResponseDto>> GetAllAsync();
        Task<PedidoResponseDto> AddAsync(PedidoRequestDto pedido);
        Task UpdateAsync(PedidoRequestDto user, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
