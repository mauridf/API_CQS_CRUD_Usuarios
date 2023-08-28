using System;
using MediatR;

namespace API_CQS_CRUD_Usuarios.Domain.Command
{
    public class UpdateUsuarioCommand : IRequest
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
    }
}
