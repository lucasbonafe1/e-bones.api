using E_Bones.Application.Dtos.Cliente;

namespace E_Bones.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteResponseDto> GetUserByIdAsync(Guid id);
        Task<IEnumerable<ClienteResponseDto>> GetAllUsersAsync();
        Task<ClienteResponseDto> AddUserAsync(ClienteRequestDto user);
        Task UpdateUserAsync(ClienteRequestDto user, Guid id);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
