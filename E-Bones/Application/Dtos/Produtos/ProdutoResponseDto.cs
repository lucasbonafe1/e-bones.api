using System.ComponentModel.DataAnnotations.Schema;

namespace E_Bones.Application.Dtos.Produtos
{
    public class ProdutoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<String> ImageUrl { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }

        public ProdutoResponseDto()
        {
            
        }
    }
}
