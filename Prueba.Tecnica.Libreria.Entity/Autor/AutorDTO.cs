using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Tecnica.Libreria.Entity.Autor
{
    public class AutorDTO
    {

        [DisplayName("ID")]
        public int idAutor { get; set; }

        [DisplayName("Nombre Completo")]
        [Required(ErrorMessage = "{0} is required")]
        public string NombreCompleto { get; set; }

        [DisplayName("Fecha de Nacimiento")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Date, ErrorMessage = "{0} no valid.")]
        public DateTime FechaNacimiento { get; set; }

        [DisplayName("Ciudad Procedencia")]
        [Required(ErrorMessage = "{0} is required")]
        public string CiudadProcedencia { get; set; }

        [DisplayName("Correo Electronico")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

    }
}
