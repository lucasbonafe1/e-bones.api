using E_Bones.Application.Dtos.Cliente;
using E_Bones.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E_Bones.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteService.GetAllAsync();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClienteRequestDto cliente)
        {
            var clienteCriado = await _clienteService.AddAsync(cliente);

            return Ok(clienteCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ClienteRequestDto cliente, Guid id)
        {
            await _clienteService.UpdateAsync(cliente, id);

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            await _clienteService.DeleteAsync(id);

            return Ok();
        }
    }
}
