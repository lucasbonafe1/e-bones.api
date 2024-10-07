using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Bones.Domain.Entities
{
    public class Notificacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("mensagem")]
        public string Mensagem { get; set; }

        [Column("cliente_id")]
        public Guid ClienteId { get; set; }

        [Column("data_envio")]
        public DateTime DataDeEnvio { get; set; }

        public DateTime? DeletedAt { get; set; }
        
        public Notificacao()
        {

        }
    }
}
