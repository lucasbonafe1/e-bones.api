using E_Bones.Application.Dtos.Pedidos;
using E_Bones.Application.Interfaces;
using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;
using E_Bones.Infrastructure.Exceptions;
using System.Collections.Generic;

namespace E_Bones.Application.Services
{
    public class PedidoService : IPedidoService 
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IPedidoRepository pedidoRepository, IProdutoRepository produtoRepository) 
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<PedidoResponseDto> AddAsync(PedidoRequestDto pedido)
        {
            ICollection<Produto> produtosDoPedido = new HashSet<Produto>();


            if (pedido == null)
            {
                throw new BadRequestException("Pedido não pode ser nulo.");
            }

            Pedido pedidoConverted = new Pedido(pedido.ClienteDoPedido, pedido.StatusPedido, pedido.Descricao);

            foreach (var produto in pedido.ProdutosID)
            {
                var produtoExistente = await _produtoRepository.GetById(produto);
                produtosDoPedido.Add(produtoExistente);
            }

            pedidoConverted.Produtos = produtosDoPedido;

            var pedidoCriado = await _pedidoRepository.Add(pedidoConverted);

            PedidoResponseDto pedidoResponse = new PedidoResponseDto(pedidoCriado);

            return pedidoResponse;
        }

        public async Task<IEnumerable<PedidoResponseDto>> GetAllAsync()
        {

            IEnumerable<Pedido> pedidos = await _pedidoRepository.GetAll();

            if (!pedidos.Any())
            {
                throw new NotFoundException("Nenhum pedido encontrado.");
            }

            var pedidoConverted = pedidos.Select(pedido => new PedidoResponseDto
            {
                Id = pedido.Id,
                ClienteDoPedido = pedido.ClienteDoPedido,
                StatusPedido = pedido.StatusPedido,
                Descricao = pedido.Descricao,
                PrecoTotal = (pedido.Produtos ?? new List<Produto>()).Sum(produto => produto.Preco),
                QuantidadeProdutos = (pedido.Produtos ?? new List<Produto>()).Count, 
                DataDeCriacao = pedido.DataDeCriacao,
                Produtos = pedido.Produtos
            });

            return pedidoConverted;
        }

        public async Task<PedidoResponseDto> GetByIdAsync(Guid id)
        {
            var pedido = await _pedidoRepository.GetById(id);

            if (pedido == null)
            {
                throw new NotFoundException("Nenhum pedido encontrado.");
            }

            PedidoResponseDto pedidoResponse = new PedidoResponseDto(pedido);

            return pedidoResponse;
        }

        public async Task UpdateAsync(PedidoRequestDto pedido, Guid id)
        {
            var pedidoExistente = await _pedidoRepository.GetById(id);

            if (pedidoExistente == null)
            {
                throw new NotFoundException("Nenhum pedido encontrado.");
            }

            pedidoExistente.ClienteDoPedido = pedido.ClienteDoPedido;
            pedidoExistente.StatusPedido = pedido.StatusPedido;
            pedidoExistente.Descricao = pedido.Descricao;

            await _pedidoRepository.Update(pedidoExistente, id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var pedido = await _pedidoRepository.GetById(id);

            return (pedido == null && pedido.DeletedAt != null) ? throw new NotFoundException("Id inexistente.") : await _pedidoRepository.Delete(id);
        }
    }
}
