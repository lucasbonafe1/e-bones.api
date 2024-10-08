using E_Bones.Application.Dtos.Cliente;

namespace E_Bones.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ClienteResponseDto>> GetAllAsync();
        Task<ClienteResponseDto> AddAsync(ClienteRequestDto user);
        Task UpdateAsync(ClienteRequestDto user, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
