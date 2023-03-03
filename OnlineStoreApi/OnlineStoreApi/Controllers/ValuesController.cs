using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApi.Data;
using OnlineStoreApi.Models;
using OnlineStoreApi.Repository;
using OnlineStoreApi.Repository.IRepository;

namespace OnlineStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ApplicationDbContext _context;
        public ValuesController(IUsuarioRepository usuarioRepository,
                                ApplicationDbContext context) 
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsuarios()
        {
            var usuarios = _usuarioRepository.GetUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{idUsuario:int}", Name = "GetUsuarioById")]
        public IActionResult GetUsuarioById(int idUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);

            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet("{nombreUsuario}", Name = "GetUsuarioByNombre")]
        public IActionResult GetUsuarioByNombre(string nombreUsuario)
        {
            var usuario = _usuarioRepository.GetUsuarioByName(nombreUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);

        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest(ModelState);
            }
            if (_usuarioRepository.ExisteUsuarioNombre(usuario.NombredeUsuario))
            {
                ModelState.AddModelError("", "El Usuario ya existe");
                return StatusCode(500, ModelState);
            }

            if (!_usuarioRepository.CrearUsuario(usuario))
            {
                ModelState.AddModelError("", $"Algo salio mal creando el equipo {usuario.Nombre}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpPatch("{usuarioId:int}", Name = "ActualizarUsuario")]
        public IActionResult ActualizarUsuario(int usuarioId, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuarioId != usuario.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_usuarioRepository.ActualizarUsuario(usuario))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el Registro{usuario.NombredeUsuario}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{idUsuario:int}", Name = "BorrarUsuario")]
        public IActionResult BorrarUsuario(int idUsuario)
        {
            if (!_usuarioRepository.ExisteUsuarioId(idUsuario))
            {
                return NotFound();
            }
            var usuario = _usuarioRepository.GetUsuarioById(idUsuario);
            if (!_usuarioRepository.BorrarUsuario(usuario))
            {
                //ModelState.AddModelError("", $"Algo salio mal Borrando el registro{producto.Id}");
                //return StatusCode(500, ModelState);
                return BadRequest(new { message = $"Algo salio mal Borrando el registro{usuario.Id}" });
            }

            return Ok();

        }

    }
}
