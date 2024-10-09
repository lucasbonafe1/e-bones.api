using E_Bones.Application.Dtos.Produtos;
using E_Bones.Domain.Entities;

namespace E_Bones.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoResponseDto> GetByIdAsync(Guid id);
        Task<IEnumerable<ProdutoResponseDto>> GetAllAsync();
        Task<ProdutoResponseDto> AddAsync(ProdutoRequestDto user);
        Task UpdateAsync(ProdutoRequestDto user, Guid id);
        Task<bool> DeleteAsync(Guid id);
    }
}
