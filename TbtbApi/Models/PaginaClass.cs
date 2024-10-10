namespace TbtbApi.Models
{
    public class PaginaClass
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Contenido { get; set; }

        public DateTime? FechaCreacion { get; set; } = default(DateTime?);
    }
}
