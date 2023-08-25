using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_CQS_CRUD_Usuarios.Domain.Entities;

namespace API_CQS_CRUD_Usuarios.Infra.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static readonly List<Usuario> _usuarios = new List<Usuario>();

        public async Task CreateAsync(Usuario usuario)
            => await Task.Run(() => _usuarios.Add(usuario));

        public async Task<IEnumerable<Usuario>> GetAllUsuario(int page, int pageSize)
            => await Task.Run(() => _usuarios.Skip((page - 1) * pageSize).Take(pageSize));
    }
}
