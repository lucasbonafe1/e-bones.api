using E_Bones.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Bones.Domain.Entities
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("cliente_pedido")]
        public Guid ClienteDoPedido { get; set; }

        [Column("status")]
        public Status StatusPedido { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("preco_total")]
        public float PrecoTotal { get; set; }

        [Column("quantidade_total")]
        public int QuantidadeProdutos { get; set; } // Soma a quantia de Produtos

        [Column("data_criacao")]
        public DateTime DataDeCriacao { get; set; }

        public ICollection<Produto> Produtos { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Pedido()
        {

        }
    }
}
