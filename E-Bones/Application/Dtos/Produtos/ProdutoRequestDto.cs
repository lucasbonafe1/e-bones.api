namespace E_Bones.Application.Dtos.Produtos
{
    public class ProdutoRequestDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public IList<String> ImageUrl { get; set; }
        public int Quantidade { get; set; }
        public float Preco { get; set; }

        public ProdutoRequestDto()
        {
            
        }
    }
}
