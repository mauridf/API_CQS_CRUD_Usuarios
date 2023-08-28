using System;

namespace API_CQS_CRUD_Usuarios.Domain.Queries.Results
{
    public class GetPagedUsersQueryResult
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
