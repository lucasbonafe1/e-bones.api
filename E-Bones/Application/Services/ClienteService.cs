using E_Bones.Application.Dtos.Cliente;
using E_Bones.Application.Interfaces;
using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;
using System.Data;

namespace E_Bones.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ClienteResponseDto> AddAsync(ClienteRequestDto clienteDto)
        {
            if (clienteDto == null) 
            {
                throw new Exception("User não pode ser nulo.");
            }    

            Cliente cliente = new Cliente(clienteDto.Nome, clienteDto.Email, clienteDto.Telefone);

            var clienteCreated = await _clienteRepository.Add(cliente);

            ClienteResponseDto clienteResponseDto = new ClienteResponseDto(clienteCreated);

            return clienteResponseDto;
        }

        public async Task<IEnumerable<ClienteResponseDto>> GetAllAsync()
        {
            IEnumerable<Cliente> clientes = await _clienteRepository.GetAll();

            if (clientes == null) 
            {
                throw new Exception("Nenhum cliente encontrado.");
            }

            var clienteConverted = clientes.Select(cliente => new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                DataDeCriacao = cliente.DataDeCriacao,
                Pedidos = cliente.Pedidos
            });

            return clienteConverted;
        }

        public async Task<ClienteResponseDto> GetByIdAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetById(id);

            if (cliente == null)
            {
                throw new Exception("Nenhum cliente encontrado.");
            }

            ClienteResponseDto clienteResponse = new ClienteResponseDto(cliente);

            return clienteResponse;
        }

        public async Task UpdateAsync(ClienteRequestDto cliente, Guid id)
        {
            var clienteExistente = await _clienteRepository.GetById(id);

            if (clienteExistente == null)
            {
                throw new Exception("Nenhum cliente encontrado.");
            }

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Telefone = cliente.Telefone;

            await _clienteRepository.Update(clienteExistente, id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var cliente = await _clienteRepository.GetById(id);

            return (cliente == null && cliente.DeletedAt != null) ? throw new Exception("Id inexistente.") : await _clienteRepository.Delete(id);
        }
    }
}
