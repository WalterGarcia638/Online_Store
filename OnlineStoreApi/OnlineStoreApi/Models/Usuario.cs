using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string NombredeUsuario { get; set; }
        public string Rol { get; set; }
    }
}
