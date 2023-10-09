using Prueba.Tecnica.Libreria.Entity.Autor;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Autores
{
    public interface IAutorRepository
    {
        public Task<List<AutorDTO>> GetAllAutorAsync();

        public Task<AutorDTO> AddAutor(AutorDTO autor);

    }
}
