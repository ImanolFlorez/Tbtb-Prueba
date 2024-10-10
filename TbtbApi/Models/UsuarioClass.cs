using System.ComponentModel.DataAnnotations;

namespace TbtbApi.Models
{
    public class UsuarioClass
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Correo { get; set; }
        public string? Rol { get; set; }
    }
}
