using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApi.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Color { get; set; }
        public string URLImagen { get; set; }
        public int IdCategoria { get; set; }
    }
}
