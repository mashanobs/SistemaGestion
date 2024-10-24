using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionEntities;
using SistemaGestionBusiness;
using Microsoft.AspNetCore.Identity.Data;

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


        // Endpoint para iniciar sesión
        [HttpPost("login")]
        public ActionResult<Usuario?> IniciarSesion([FromBody] Usuario credenciales)
        {
            var usuario = _usuariosBusiness.IniciarSesion(credenciales.Email, credenciales.Contraseña);
            if (usuario == null)
            {
                return Unauthorized();
            }
            return usuario;
        }

        // Endpoint para obtener el nombre de un usuario por su ID
        [HttpGet("{id}/nombre")]
        public ActionResult<string> GetNombreUsuario([FromRoute(Name = "id")] int id)
        {
            var nombre = _usuariosBusiness.GetNombreUsuario(id);
            if (nombre == null)
            {
                return NotFound(); // Si no se encuentra el usuario, retornamos un error 404
            }
            return Ok(nombre);
        }
    }
}

