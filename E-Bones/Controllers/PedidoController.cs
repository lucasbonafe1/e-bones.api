using E_Bones.Application.Dtos.Cliente;
using E_Bones.Application.Dtos.Pedidos;
using E_Bones.Application.Interfaces;
using E_Bones.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Bones.Controllers
{
    [ApiController]
    [Route("pedidos")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _pedidoService.GetAllAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);

            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PedidoRequestDto pedido)
        {
            var pedidoCriado = await _pedidoService.AddAsync(pedido);

            return Ok(pedidoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] PedidoRequestDto pedido, Guid id)
        {
            await _pedidoService.UpdateAsync(pedido, id);

            return Ok(pedido);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _pedidoService.DeleteAsync(id);

            return Ok();
        }
    }
}
