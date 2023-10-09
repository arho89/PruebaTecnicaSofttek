using Prueba.Tecnica.Libreria.Entity.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Lirbos
{
    public interface ILibroRepository
    {
        public Task<List<LibroDTO>> GetAllLibrosAsync();

        public Task<LibroDTO> AddLibro(LibroDTO libro, int cantidadLibrosPermitidos);
    }
}
