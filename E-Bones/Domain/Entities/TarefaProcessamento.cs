using E_Bones.Domain.Enum;

namespace E_Bones.Domain.Entities
{
    public class TarefaDeProcessamento
    {
        public Guid Id { get; set; }
        public string TipoDeTarefa { get; set; }           // Tipo de tarefa ProcessOrder, GenerateReport, etc.
        public Status Status { get; set; }            // Status (Pendente, Concluído, Falhou)
        public DateTime DataCriacao { get; set; }
        public DateTime? DataDeTermino { get; set; }

        public TarefaDeProcessamento()
        {

        }
    }
}
