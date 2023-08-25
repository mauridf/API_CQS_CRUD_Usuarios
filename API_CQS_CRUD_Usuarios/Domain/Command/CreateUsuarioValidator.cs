using FluentValidation;
using API_CQS_CRUD_Usuarios.Domain.Entities;

namespace API_CQS_CRUD_Usuarios.Domain.Command
{
    public class CreateUsuarioValidator : AbstractValidator<Usuario>
    {
        public CreateUsuarioValidator()
        {
            RuleFor(expression: x => x.Nome)
                .NotEmpty()
                .Length(min: 10, max: 256);
            RuleFor(expression: x => x.Senha)
                .NotEmpty()
                .Length(min: 10, max: 256);
            RuleFor(expression: x => x.DataNascimento)
                .NotEmpty();
        }
    }
}
