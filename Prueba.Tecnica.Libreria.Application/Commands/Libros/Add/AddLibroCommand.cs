using MediatR;
using Prueba.Tecnica.Libreria.Entity.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Commands.Libros.Add
{
    public class AddLibroCommand : IRequest<LibroDTO>
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public int idGenero { get; set; }
        public string genero { get; set; }
        public int año { get; set; }
        public int numeroPaginas { get; set; }
        public int idAutor { get; set; }
        public string autor { get; set; }
        public int cantidadDeLibrosPermitidos { get; set; }

    }
}
