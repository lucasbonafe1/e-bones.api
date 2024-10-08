using E_Bones.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Bones.Application.Dtos.Cliente
{
    public class ClienteResponseDto
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public DateTime DataDeCriacao { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } // TODO: Trocar para PedidosResponseDto depois de criar e configurar

        public ClienteResponseDto()
        { }

        public ClienteResponseDto(Domain.Entities.Cliente clienteCreated)
        {
            Id = clienteCreated.Id;
            Nome = clienteCreated.Nome;
            Email = clienteCreated.Email;
            Telefone = clienteCreated.Telefone;
            DataDeCriacao = clienteCreated.DataDeCriacao;
            Pedidos = clienteCreated.Pedidos;
        }
    }
}
