using E_Bones.Domain.Enum;

namespace E_Bones.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<String> ImageUrl { get; set; }
        public int Quantidade { get; set; }
        public float Preco{ get; set; }
    }
}