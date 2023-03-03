using OnlineStoreApi.Data;
using OnlineStoreApi.Models;
using OnlineStoreApi.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStoreApi.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public bool ActualizarProducto(Producto producto)
        {
            _context.Producto.Update(producto);
            return Guardar();
        }

        public bool BorrarProducto(Producto producto)
        {
            _context.Producto.Remove(producto);
            return Guardar();
        }

        public bool CrearProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            return Guardar();
        }

        public bool ExisteProductoId(int idProducto)
        {
            return _context.Producto.Any(I => I.Id == idProducto);

        }

        public bool ExisteProductoNombre(string nombreProducto)
        {
            bool valor = _context.Producto.Any(I => I.Nombre.ToLower().Trim() == nombreProducto.ToLower().Trim());
            return valor;
        }

        public Producto GetProductoById(int idProducto)
        {
            return _context.Producto.FirstOrDefault(I => I.Id == idProducto);
        }

        public Producto GetProductoByName(string nombreProducto)
        {
            return _context.Producto.FirstOrDefault(I => I.Nombre == nombreProducto);
        }

        public ICollection<Producto> GetProductos()
        {
            return _context.Producto.OrderBy(I => I.Id).ToList();
        }

        public bool Guardar()
        {
            return _context.SaveChanges() >=0 ? true : false;
        }
    }
}
