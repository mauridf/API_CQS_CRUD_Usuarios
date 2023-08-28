using System;
using API_CQS_CRUD_Usuarios.Domain.Command;

namespace API_CQS_CRUD_Usuarios.Domain.Entities
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, string nome, DateTime nascimento, string senha)
        {
            IdUsuario = id;
            Nome = nome;
            Senha = senha;
            DataNascimento = nascimento;
            DataCriacao = DateTime.Now;
            Ativo = true;
        }

        public static Usuario Create(CreateUsuarioCommand command)
            => new Usuario(command.IdUsuario, command.Nome, command.DataNascimento, command.Senha);
    }
}
