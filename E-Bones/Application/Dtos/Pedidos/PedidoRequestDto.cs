using E_Bones.Domain.Entities;
using E_Bones.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Bones.Application.Dtos.Pedidos
{
    public class PedidoRequestDto
    {
        public Guid ClienteDoPedido { get; set; }
        public Status StatusPedido { get; set; }
        public string Descricao { get; set; }
    }
}
