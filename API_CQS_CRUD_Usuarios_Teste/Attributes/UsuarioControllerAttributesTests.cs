using System;
using System.Net;
using System.Net.Mime;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_CQS_CRUD_Usuarios_Teste.AssertExtensions;
using API_CQS_CRUD_Usuarios_Teste.Fixtures;
using API_CQS_CRUD_Usuarios.Controllers;
using Xunit;

namespace API_CQS_CRUD_Usuarios_Teste.Attributes
{
    public class UsuarioControllerAttributesTests : IClassFixture<AttributeFixture<UsuarioController>>
    {
        private readonly AttributeFixture<UsuarioController> _attribute;

        public UsuarioControllerAttributesTests(AttributeFixture<UsuarioController> attribute)
        {
            _attribute = attribute ?? throw new ArgumentNullException(nameof(attribute));
        }

        [Fact]
        public void Controller()
        {
            var attributes = _attribute.GetTCustomAttributes();

            attributes[0].Should().BeOfType<ApiControllerAttribute>();

            attributes[1].Should().BeOfType<RouteAttribute>();
            attributes[1].Should().WithRouteTemplate("[controller]");

            attributes[2].Should().BeOfProducesAttribute(MediaTypeNames.Application.Json);
            attributes[3].Should().BeOfType<ControllerAttribute>();
        }

        [Fact]
        public void GetUsuarios()
        {
            _attribute.GetMethod(nameof(UsuarioController.BuscarTodosUsuarios));

            var attributes = _attribute.GetCustomAttributes();

            attributes[2].Should().BeOfHttpAttribute<HttpGetAttribute>(WebRequestMethods.Http.Get);
            attributes[3].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status200OK);
        }

        [Fact]
        public void CreateUsuario()
        {
            _attribute.GetMethod(nameof(UsuarioController.CriarNovoUsuario));

            var attributes = _attribute.GetCustomAttributes();

            attributes[2].Should().BeOfHttpAttribute<HttpPostAttribute>(WebRequestMethods.Http.Post);

            attributes[3].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status201Created);
            attributes[4].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public void UpdateTodoItem()
        {
            _attribute.GetMethod(nameof(UsuarioController.EditarUsuario));

            var attributes = _attribute.GetCustomAttributes();

            attributes[2].Should().BeOfHttpAttribute<HttpPutAttribute>(WebRequestMethods.Http.Put);

            attributes[3].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status204NoContent);
            attributes[4].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status400BadRequest);
            attributes[5].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status404NotFound);
        }

        [Fact]
        public void DeleteTodoItem()
        {
            _attribute.GetMethod(nameof(UsuarioController.DeletarUsuario));

            var attributes = _attribute.GetCustomAttributes();

            attributes[2].Should().BeOfHttpAttribute<HttpDeleteAttribute>("DELETE");
            attributes[2].Should().WithHttpTemplate<HttpDeleteAttribute>("{id}");

            attributes[3].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status204NoContent);
            attributes[4].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status400BadRequest);
            attributes[5].Should().BeOfProducesResponseTypeAttribute(StatusCodes.Status404NotFound);
        }
    }
}
