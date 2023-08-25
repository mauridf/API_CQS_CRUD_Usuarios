using API_CQS_CRUD_Usuarios.Domain.Command;
using API_CQS_CRUD_Usuarios.Domain.Entities;
using API_CQS_CRUD_Usuarios.Infra.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace API_CQS_CRUD_Usuarios.Domain.CommandHandlers
{
    public class UsuarioCommandHandler : AsyncRequestHandler<CreateUsuarioCommand>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        protected override async Task Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = Usuario.Create(request);

            await _usuarioRepository.CreateAsync(user);
        }
    }
}
