using OnlineStoreApi.Models;
using System.Collections.Generic;

namespace OnlineStoreApi.Repository.IRepository
{
    public interface IProductoRepository
    {
        ICollection<Producto> GetProductos();
        Producto GetProductoById(int idProducto);
        Producto GetProductoByName(string nombreProducto);
        bool ExisteProductoNombre(string nombreProducto);
        bool ExisteProductoId(int idProducto);
        bool CrearProducto(Producto producto);
        bool ActualizarProducto(Producto producto);
        bool BorrarProducto(Producto producto);
        bool Guardar();

    }
}
