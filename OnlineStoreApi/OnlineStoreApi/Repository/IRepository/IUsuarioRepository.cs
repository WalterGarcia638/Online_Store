using OnlineStoreApi.Models;
using System.Collections.Generic;

namespace OnlineStoreApi.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuarios();
        Usuario GetUsuarioById(int idUsuario);
        Usuario GetUsuarioByName(string nombreUsuario);
        bool ExisteUsuarioNombre(string nombreUsuario);
        bool ExisteUsuarioId(int idUsuario);
        bool CrearUsuario(Usuario usuario);
        bool ActualizarUsuario(Usuario usuario);
        bool BorrarUsuario(Usuario usuario);
        bool Guardar();
    }
}
