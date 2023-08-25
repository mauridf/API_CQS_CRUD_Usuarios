using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_CQS_CRUD_Usuarios.Domain.Entities;

namespace API_CQS_CRUD_Usuarios.Infra.Data
{
    public interface IUsuarioRepository
    {
        Task CreateAsync(Usuario user);
        Task<IEnumerable<Usuario>> GetAllUsuario(int page, int pageSize);

    }
}
