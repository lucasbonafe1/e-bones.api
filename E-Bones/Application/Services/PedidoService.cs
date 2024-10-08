using E_Bones.Application.Dtos.Pedidos;
using E_Bones.Application.Interfaces;
using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;

namespace E_Bones.Application.Services
{
    public class PedidoService : IPedidoService 
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository) 
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<PedidoResponseDto> AddAsync(PedidoRequestDto pedido)
        {
            if (pedido == null)
            {
                throw new Exception("Pedido não pode ser nulo.");
            }

            Pedido pedidoConverted = new Pedido(pedido.ClienteDoPedido, pedido.StatusPedido, pedido.Descricao);

            var pedidoCriado = await _pedidoRepository.Add(pedidoConverted);

            PedidoResponseDto pedidoResponse = new PedidoResponseDto(pedidoCriado);

            return pedidoResponse;
        }

        public async Task<IEnumerable<PedidoResponseDto>> GetAllAsync()
        {
            IEnumerable<Pedido> pedidos = await _pedidoRepository.GetAll();

            if (pedidos == null)
            {
                throw new Exception("Nenhum cliente encontrado.");
            }

            var pedidoConverted = pedidos.Select(pedidoCriado => new PedidoResponseDto
            {
                Id = pedidoCriado.Id,
                ClienteDoPedido = pedidoCriado.ClienteDoPedido,
                StatusPedido = pedidoCriado.StatusPedido,
                Descricao = pedidoCriado.Descricao,
                PrecoTotal = pedidoCriado.PrecoTotal,
                QuantidadeProdutos = pedidoCriado.QuantidadeProdutos,
                DataDeCriacao = pedidoCriado.DataDeCriacao,
                Produtos = pedidoCriado.Produtos
            });

            return pedidoConverted;
        }

        public async Task<PedidoResponseDto> GetByIdAsync(Guid id)
        {
            var pedido = await _pedidoRepository.GetById(id);

            if (pedido == null)
            {
                throw new Exception("Nenhum pedido encontrado.");
            }

            PedidoResponseDto pedidoResponse = new PedidoResponseDto(pedido);

            return pedidoResponse;
        }

        public async Task UpdateAsync(PedidoRequestDto pedido, Guid id)
        {
            var pedidoExistente = await _pedidoRepository.GetById(id);

            if (pedidoExistente == null)
            {
                throw new Exception("Nenhum pedido encontrado.");
            }

            pedidoExistente.ClienteDoPedido = pedido.ClienteDoPedido;
            pedidoExistente.StatusPedido = pedido.StatusPedido;
            pedidoExistente.Descricao = pedido.Descricao;

            await _pedidoRepository.Update(pedidoExistente, id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var pedido = await _pedidoRepository.GetById(id);

            return (pedido == null && pedido.DeletedAt != null) ? throw new Exception("Id inexistente.") : await _pedidoRepository.Delete(id);
        }
    }
}
