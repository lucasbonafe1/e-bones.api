using E_Bones.Domain.Enum;

namespace E_Bones.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public Cliente ClienteDoPedido { get; set; }
        public Status StatusPedido { get; set; }
        public string Descricao { get; set; }
        public float PrecoTotal { get; set; }
        public int QuantidadeProdutos { get; set; } // Soma a quantia de Produtos
        public DateTime DataDeCriacao { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public Pedido()
        {

        }
    }
}
