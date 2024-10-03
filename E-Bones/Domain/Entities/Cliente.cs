namespace E_Bones.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

        public Cliente() { 
        }
    }
}
