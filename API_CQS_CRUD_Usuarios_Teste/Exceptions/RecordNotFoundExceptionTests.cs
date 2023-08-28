using FluentAssertions;
using API_CQS_CRUD_Usuarios.Domain.Exception;
using Xunit;

namespace API_CQS_CRUD_Usuarios_Teste.Exceptions
{
    public class RecordNotFoundExceptionTests
    {
        [Fact]
        public void WithCustomErrorMessage()
        {
            const string entity = "entity";
            const long key = 1;

            // Arrange
            var exception = new RecordNotFoundException(entity, key);

            // Assert
            exception.Message.Should().Be($"Entity '{entity}' does not matter with the '{key}' key.");
        }
    }
}
