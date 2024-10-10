using E_Bones.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace E_Bones.Domain.Entities
{
    public class TarefaDeProcessamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("tipo")]
        public string TipoDeTarefa { get; set; }           // Tipo de tarefa ProcessOrder, GenerateReport, etc.

        [Column("status")]
        public Status Status { get; set; }            // Status (Pendente, Concluído, Falhou)

        [Column("data_criacao")]
        public DateTime DataCriacao { get; set; }

        [Column("data_termino")]
        public DateTime? DataDeTermino { get; set; }

        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }

        public TarefaDeProcessamento()
        {

        }
    }
}
