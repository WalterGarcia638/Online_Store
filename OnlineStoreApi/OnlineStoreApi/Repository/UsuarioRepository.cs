using OnlineStoreApi.Data;
using OnlineStoreApi.Models;
using OnlineStoreApi.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace OnlineStoreApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApplicationDbContext _context;

        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool ActualizarUsuario(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            return Guardar();
        }

        public bool BorrarUsuario(Usuario usuario)
        {
            _context.Usuario.Remove(usuario);
            return Guardar();
        }

        public bool CrearUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            return Guardar();
        }

        public bool ExisteUsuarioId(int idUsuario)
        {
            return _context.Usuario.Any(I => I.Id == idUsuario);
        }

        public bool ExisteUsuarioNombre(string nombreUsuario)
        {
            bool valor = _context.Usuario.Any(I => I.NombredeUsuario.ToLower().Trim() == nombreUsuario.ToLower().Trim());
            return valor;
        }

        public Usuario GetUsuarioById(int idUsuario)
        {
            return _context.Usuario.FirstOrDefault(I => I.Id == idUsuario);
        }

        public Usuario GetUsuarioByName(string nombreUsuario)
        {
            return _context.Usuario.FirstOrDefault(I => I.NombredeUsuario == nombreUsuario);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _context.Usuario.OrderBy(I => I.Id).ToList();
        }

        public bool Guardar()
        {
            throw new System.NotImplementedException();
        }
    }
}
