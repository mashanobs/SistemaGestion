using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBusiness;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly UsuarioBusiness _usuariosBusiness;

        public UsuariosController(ILogger<UsuariosController> logger, UsuarioBusiness usuariosBusiness)
        {
            _logger = logger;
            _usuariosBusiness = usuariosBusiness;
        }

        [HttpGet(Name = "Get Usuarios")]
        public ActionResult<List<Usuario>> GetUsuarios([FromQuery(Name = "filtro")] string? filtro)
        {
            if (filtro == null)
            {
                return _usuariosBusiness.GetUsuarios();
            }
            return _usuariosBusiness.GetUsuariosBy(filtro);
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario([FromRoute(Name = "id")] int id)
        {
            _logger.LogInformation("Consultando por el producto con id {id}", id);
            var usuario = _usuariosBusiness.GetOneUsuario(id);
            if (usuario is null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> CrearUsuario([FromBody] Usuario usuario)
        {
            var usuarioCreado = _usuariosBusiness.InsertUsuario(usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = usuarioCreado.Id }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult ModificarUsuario([FromRoute(Name = "id")] int id, [FromBody] Usuario usuario)
        {
            _usuariosBusiness.UpdateUsuario(id, usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario([FromRoute(Name = "id")] int id)
        {
            _usuariosBusiness.DeleteUsuario(id);
            return NoContent();
        }
    }
}
