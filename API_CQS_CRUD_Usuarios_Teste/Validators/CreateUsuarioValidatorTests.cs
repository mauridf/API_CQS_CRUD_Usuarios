using System;
using System.Linq;
using FluentAssertions;
using FluentValidation.TestHelper;
using API_CQS_CRUD_Usuarios.Domain.Entities;
using API_CQS_CRUD_Usuarios.Domain.Command;
using API_CQS_CRUD_Usuarios_Teste.Fixtures;
using Xunit;

namespace API_CQS_CRUD_Usuarios_Teste.Validators
{
    public class CreateUsuarioValidatorTests : IClassFixture<ValidatorFixture<CreateUsuarioValidator>>
    {
        private readonly CreateUsuarioValidator _validator;

        public CreateUsuarioValidatorTests(ValidatorFixture<CreateUsuarioValidator> validator)
        {
            _validator = validator?.Instance ?? throw new ArgumentNullException(nameof(validator));
        }

        [Fact]
        public void IsValidTests()
        {
            _validator.TestValidate(new Usuario
            {
                Nome = "Fulano",
                Senha = "123456",
                DataNascimento = Convert.ToDateTime("30/08/1977"),
                DataCriacao = DateTime.Now,
                Ativo = true,
            }).Should().NotBeNull();

            _validator.TestValidate(new Usuario
            {
                Nome = "Ciclano",
                Senha = "Teste123",
                DataNascimento = Convert.ToDateTime("14/03/1988"),
                DataCriacao = DateTime.Now,
                Ativo = true,
            }).Should().NotBeNull();
        }
    }
}
