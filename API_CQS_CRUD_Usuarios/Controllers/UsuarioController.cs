using API_CQS_CRUD_Usuarios.Domain.Command;
using API_CQS_CRUD_Usuarios.Domain.Notification;
using API_CQS_CRUD_Usuarios.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace API_CQS_CRUD_Usuarios.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IMediator _bus;
        private readonly IDomainNotificationContext _notificationContext;

        public UsuarioController(IMediator bus, IDomainNotificationContext notificationContext)
        {
            _bus = bus;
            _notificationContext = notificationContext;
        }

        // GET: UsuarioController/Create
        [HttpPost]
        [Route("v1/CriarNovoUsuario")]
        public async Task<IActionResult> CriarNovoUsuario([FromBody] CreateUsuarioCommand command)
        {
            await _bus.Send(command);

            if (_notificationContext.HasErrorNotifications)
            {
                var notifications = _notificationContext.GetErrorNotifications();
                var message = string.Join(", ", notifications.Select(x => x.Value));
                return BadRequest(message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("v1/BuscarTodosUsuarios")]
        public async Task<IActionResult> BuscarTodosUsuarios([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var query = GetPagedUsuariosQuery.Create(page, pageSize);
            var pagedUsers = await _bus.Send(query);
            return Ok(pagedUsers);
        }

        [HttpPatch]
        [Route("v1/EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(UpdateUsuarioCommand usuarioResultUpdateCommand)
        {
            var result = await _bus.Send(usuarioResultUpdateCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("v1/DeletarUsuario")]
        public async Task<IActionResult> DeletarUsuario(DeleteUsuarioCommand usuarioResultDeleteCommand)
        {
            var result = await _bus.Send(usuarioResultDeleteCommand);
            return Ok(result);
        }
    }
}
