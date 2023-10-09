using MediatR;
using Prueba.Tecnica.Libreria.Entity.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Commands.Autores.Add
{
    public class AddAutorCommand : IRequest<AutorDTO>
    {
        public int idAutor { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadProcedencia { get; set; }
        public string CorreoElectronico { get; set; }

    }
}
