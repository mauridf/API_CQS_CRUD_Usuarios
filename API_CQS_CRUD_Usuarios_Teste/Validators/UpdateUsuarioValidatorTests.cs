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
    public class UpdateUsuarioValidatorTests : IClassFixture<ValidatorFixture<UpdateUsuarioValidator>>
    {
        private readonly UpdateUsuarioValidator _validator;

        public UpdateUsuarioValidatorTests(ValidatorFixture<UpdateUsuarioValidator> validator)
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
        }

        [Theory]
        [InlineData(null, "'IdUsuario' must not be empty.")]
        [InlineData(0, "'IdUsuario' must be greater than '0'.")]
        public void IdIsNull(int id, string message)
        {
            // Arrange
            var dto = new Usuario
            {
                IdUsuario = id,
                Nome = "Fulano",
                Senha = "123456",
                DataNascimento = Convert.ToDateTime("30/08/1977"),
                DataCriacao = DateTime.Now,
                Ativo = true,
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.Should().BeNull();
            result.ShouldHaveError().FirstOrDefault(x => x.ErrorMessage == message).Should().NotBeNull();
        }

        [Fact]
        public void NomeIsNull()
        {
            // Arrange
            var dto = new Usuario
            {
                IdUsuario = 1,
                Nome = null,
                Senha = "Teste123",
                DataNascimento = Convert.ToDateTime("14/03/1988"),
                DataCriacao = DateTime.Now,
                Ativo = true,
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.Should().BeNull();
            result.ShouldHaveError().Single().ErrorMessage.Should().Be("'Nome' must not be empty.");
            result.ShouldHaveError().Should().HaveCount(1);
        }

        [Fact]
        public void SenhaIsNull()
        {
            // Arrange
            var dto = new Usuario
            {
                IdUsuario = 1,
                Nome = "Fulano",
                Senha = null,
                DataNascimento = Convert.ToDateTime("14/03/1988"),
                DataCriacao = DateTime.Now,
                Ativo = true,
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.Should().BeNull();
            result.ShouldHaveError().Single().ErrorMessage.Should().Be("'Senha' must not be empty.");
            result.ShouldHaveError().Should().HaveCount(1);
        }
    }
}
