using API_CQS_CRUD_Usuarios.Domain.Queries;
using API_CQS_CRUD_Usuarios.Domain.Queries.Results;
using API_CQS_CRUD_Usuarios.Infra.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace API_CQS_CRUD_Usuarios.Domain.QueryHandlers
{
    public class UsuarioQueryHandler : IRequestHandler<GetPagedUsuariosQuery, IEnumerable<GetPagedUsersQueryResult>>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<GetPagedUsersQueryResult>> Handle(GetPagedUsuariosQuery request, CancellationToken cancellationToken)
        {
            var users = await _usuarioRepository.GetAllUsuario(request.Page, request.PageSize);

            return users.Select(x => new GetPagedUsersQueryResult
            {
                IdUsuario = x.IdUsuario,
                Nome = x.Nome,
                DataNascimento = x.DataNascimento,
                DataCriacao = x.DataCriacao,
                Ativo = x.Ativo,
            });
        }
    }
}
