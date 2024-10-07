using E_Bones.Application.Dtos.Cliente;
using E_Bones.Application.Interfaces;
using E_Bones.Domain.Repositories;

namespace E_Bones.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<ClienteResponseDto> AddUserAsync(ClienteRequestDto user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteResponseDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ClienteResponseDto> GetUserByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(ClienteRequestDto user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
