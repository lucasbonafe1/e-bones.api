using E_Bones.Application.Dtos.Cliente;
using E_Bones.Application.Dtos.Produtos;
using E_Bones.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Bones.Controllers
{
    [ApiController]
    [Route("produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;
        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await _produtoService.GetAllAsync();

            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var produto = await _produtoService.GetByIdAsync(id);

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProdutoRequestDto produto)
        {
            var produtoCriado = await _produtoService.AddAsync(produto);

            return Ok(produtoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProdutoRequestDto produto, Guid id)
        {
            await _produtoService.UpdateAsync(produto, id);

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _produtoService.DeleteAsync(id);

            return Ok();
        }
    }
}
