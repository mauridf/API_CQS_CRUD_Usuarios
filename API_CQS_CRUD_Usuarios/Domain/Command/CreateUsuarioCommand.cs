using System;
using MediatR;

namespace API_CQS_CRUD_Usuarios.Domain.Command
{
    public class CreateUsuarioCommand : IRequest
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
