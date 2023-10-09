using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Tecnica.Libreria.Entity.Libro
{
    public class LibroDTO
    {
        [DisplayName("ID")]
        public int id { get; set; }

        [DisplayName("Titulo")]
        [Required(ErrorMessage = "{0} is required")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int idGenero { get; set; }
        public string? genero { get; set; }

        [DisplayName("Año")]
        [Required(ErrorMessage = "{0} is required")]
        [Range(-10000, 2023, ErrorMessage = "{0} no valid.")]
        public int año { get; set; }

        [DisplayName("Numero de Paginas")]
        [Required(ErrorMessage = "{0} is required")]
        [Range(1, 20000, ErrorMessage = "{0} no valid.")]
        public int numeroPaginas { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int idAutor { get; set; }
        public string? autor { get; set; }
    }
}
