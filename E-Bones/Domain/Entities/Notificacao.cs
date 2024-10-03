namespace E_Bones.Domain.Entities
{
    public class Notificacao
    {
        public Guid Id { get; set; }
        public string Mensagem { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataDeEnvio { get; set; }
        //Rever Atributos
        public Notificacao()
        {

        }
    }
}
