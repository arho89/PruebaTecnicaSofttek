using Prueba.Tecnica.Libreria.Entity.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Autores
{
    public interface IAutorRepository
    {
        public Task<List<AutorDTO>> GetAllAutorAsync();

        public Task<AutorDTO> AddAutor(AutorDTO autor);

    }
}
