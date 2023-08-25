using API_CQS_CRUD_Usuarios.Domain.Command;
using FluentValidation;
using System;

namespace API_CQS_CRUD_Usuarios.Domain.Validations
{
    public class CreateUsuarioCommandValidation : AbstractValidator<CreateUsuarioCommand>
    {
        public CreateUsuarioCommandValidation()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().WithMessage("O Nome é obrigatório");
            RuleFor(x => x.DataNascimento).NotNull().WithMessage("A Data de Nascimento é obrigatória");
            RuleFor(x => x.DataNascimento).Must(birthDay => new DateTime(birthDay.Year - 18, birthDay.Month, birthDay.Day) >= birthDay).WithMessage("Menores de Idade não são permitidos");
        }
    }
}
