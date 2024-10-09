using E_Bones.Domain.Entities;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Bones.Application.Dtos.Produtos
{
    public class ProdutoResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IList<String> ImageUrl { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }

        public ProdutoResponseDto()
        {
            
        }

        public ProdutoResponseDto(Produto produtoCreated)
        {
            Id = produtoCreated.Id;
            Nome = produtoCreated.Nome;
            Descricao = produtoCreated.Descricao;
            ImageUrl = produtoCreated.ImageUrl;
            Quantidade = produtoCreated.Quantidade;
            Preco = produtoCreated.Preco;
        }
    }
}
