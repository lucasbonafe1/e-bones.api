using E_Bones.Application.Dtos.Produtos;
using E_Bones.Application.Interfaces;
using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;
using E_Bones.Infrastructure.Exceptions;

namespace E_Bones.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoResponseDto> AddAsync(ProdutoRequestDto produto)
        {
            if (produto == null)
            {
                throw new BadRequestException("Produto não pode ser nulo.");
            }

            Produto produtoConverted = new Produto(produto.Nome, produto.Descricao, produto.ImageUrl, produto.Quantidade, produto.Preco);

            var produtoCreated = await _produtoRepository.Add(produtoConverted);

            ProdutoResponseDto produtoResponseDto = new ProdutoResponseDto(produtoCreated);

            return produtoResponseDto;
        }

        public async Task<IEnumerable<ProdutoResponseDto>> GetAllAsync()
        {
            IEnumerable<Produto> produtos = await _produtoRepository.GetAll();

            if (!produtos.Any())
            {
                throw new NotFoundException("Nenhum produto encontrado.");
            }

            var produtoConverted = produtos.Select(produto => new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                ImageUrl = produto.ImageUrl,
                Quantidade = produto.Quantidade,
                Preco = produto.Preco
            });

            return produtoConverted;
        }

        public async Task<ProdutoResponseDto> GetByIdAsync(Guid id)
        {
            var produto = await _produtoRepository.GetById(id);

            if (produto == null)
            {
                throw new NotFoundException("Nenhum produto encontrado.");
            }

            ProdutoResponseDto produtoResponse = new ProdutoResponseDto(produto);

            return produtoResponse;
        }

        public async Task UpdateAsync(ProdutoRequestDto produto, Guid id)
        {
            var produtoExistente = await _produtoRepository.GetById(id);

            if (produtoExistente == null)
            {
                throw new NotFoundException("Nenhum produto encontrado.");
            }

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Descricao = produto.Descricao;
            produtoExistente.ImageUrl = produto.ImageUrl;
            produtoExistente.Quantidade = produto.Quantidade;
            produtoExistente.Preco = produto.Preco;

            await _produtoRepository.Update(produtoExistente, id);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var produto = await _produtoRepository.GetById(id);

            return (produto == null && produto.DeletedAt != null) ? throw new NotFoundException("Id inexistente.") : await _produtoRepository.Delete(id);
        }
    }
}
