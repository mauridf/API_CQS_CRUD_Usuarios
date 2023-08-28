using System;
using MediatR;

namespace API_CQS_CRUD_Usuarios.Domain.Command
{
    public class DeleteUsuarioCommand :IRequest
    {
        public int IdUsuario { get; set; }
    }
}
