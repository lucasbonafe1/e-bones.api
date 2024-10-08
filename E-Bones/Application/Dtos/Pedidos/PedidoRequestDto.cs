using E_Bones.Domain.Entities;
using E_Bones.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Bones.Application.Dtos.Pedidos
{
    public class PedidoRequestDto
    {
        public Guid ClienteDoPedido { get; set; }
        public Status StatusPedido { get; set; } // setar para que quando acabar de ser criado o pedido ficar como processando
        public string Descricao { get; set; }
        //public float PrecoTotal { get; set; } // soma preco de cada produto e gera um total
        //public int QuantidadeProdutos { get; set; } // Soma a quantia de Produtos
    }
}
