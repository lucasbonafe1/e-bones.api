using E_Bones.Domain.Entities;
using E_Bones.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Bones.Application.Dtos.Pedidos
{
    public class PedidoResponseDto
    {
        public Guid Id { get; set; }
        public Guid ClienteDoPedido { get; set; }
        public Status StatusPedido { get; set; }
        public string Descricao { get; set; }
        public float PrecoTotal { get; set; }
        public int QuantidadeProdutos { get; set; } // Soma a quantia de Produtos
        public DateTime DataDeCriacao { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public PedidoResponseDto()
        {
        }

        public PedidoResponseDto(Pedido pedidoCriado)
        {
            Id = pedidoCriado.Id;
            ClienteDoPedido = pedidoCriado.ClienteDoPedido;
            StatusPedido = pedidoCriado.StatusPedido;
            Descricao = pedidoCriado.Descricao;
            PrecoTotal = pedidoCriado.PrecoTotal;
            QuantidadeProdutos = pedidoCriado.QuantidadeProdutos;
            DataDeCriacao = pedidoCriado.DataDeCriacao;
            Produtos  = pedidoCriado.Produtos;
        }
    }
}
