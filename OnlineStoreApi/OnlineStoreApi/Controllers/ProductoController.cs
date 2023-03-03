using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreApi.Data;
using OnlineStoreApi.Models;
using OnlineStoreApi.Repository.IRepository;

namespace OnlineStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private  readonly ApplicationDbContext _context; 
        public ProductoController( IProductoRepository productoRepository,
                                   ApplicationDbContext context ) 
        {
            _productoRepository = productoRepository;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProductos() 
        {
            var productos = _productoRepository.GetProductos();
            return Ok(productos);
        }

        [HttpGet("{idProducto:int}", Name = "GetProductoById")]
        public IActionResult GetProductoById(int idProducto) 
        {
            var producto = _productoRepository.GetProductoById(idProducto);

            if (producto == null) 
            {
                return NotFound();
            }
            return Ok(producto);
        }
        [HttpGet("{nombreProducto}", Name = "GetProductoByNombre")]
        public IActionResult GetProductoByNombre(string nombreProducto)
        {
            var producto =_productoRepository.GetProductoByName(nombreProducto);

            if (producto == null) 
            {
                return NotFound();
            }

            return Ok(producto);

        }

        [HttpPost]
        public IActionResult CrearProducto([FromBody] Producto producto) 
        {
            if (producto == null) 
            {
                return BadRequest(ModelState);
            }
            if (_productoRepository.ExisteProductoNombre(producto.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return StatusCode(500, ModelState);
            }

            if (!_productoRepository.CrearProducto(producto)) 
            {
                ModelState.AddModelError("",$"Algo salio mal creando el equipo {producto.Nombre}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
        [HttpPatch("{productoId:int}", Name = "ActualizarProducto")]
        public IActionResult ActualizarProducto(int productoId, [FromBody] Producto producto) 
        {
            if (producto ==null || productoId != producto.Id) 
            {
                return BadRequest(ModelState);
            }

            if (!_productoRepository.ActualizarProducto(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el Registro{producto.Nombre}");
                return StatusCode(500,ModelState);
            }
            return NoContent();        
        }

        [HttpDelete("{idProducto:int}", Name = "BorrarProducto")]
        public IActionResult BorrarProducto(int idProducto)
        {
            if (!_productoRepository.ExisteProductoId(idProducto)) 
            {
                return NotFound();
            }
            var producto = _productoRepository.GetProductoById(idProducto);
            if (!_productoRepository.BorrarProducto(producto))
            {
                //ModelState.AddModelError("", $"Algo salio mal Borrando el registro{producto.Id}");
                //return StatusCode(500, ModelState);
               return BadRequest(new { message = $"Algo salio mal Borrando el registro{producto.Id}" } );
            }

            return Ok();

        }
    }
}
