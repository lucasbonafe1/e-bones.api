using E_Bones.Domain.Entities;
using E_Bones.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Bones.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteRepository.GetAll();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _clienteRepository.GetById(id);

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Cliente cliente)
        {
            var clienteCriado = await _clienteRepository.Add(cliente);

            return Ok(clienteCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Cliente cliente, Guid id)
        {
            await _clienteRepository.Update(cliente, id);

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            await _clienteRepository.Delete(id);

            return Ok();
        }
    }
}
