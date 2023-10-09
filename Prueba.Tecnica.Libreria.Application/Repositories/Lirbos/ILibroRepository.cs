using Prueba.Tecnica.Libreria.Entity.Libro;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Lirbos
{
    public interface ILibroRepository
    {
        public Task<List<LibroDTO>> GetAllLibrosAsync();

        public Task<LibroDTO> AddLibro(LibroDTO libro, int cantidadLibrosPermitidos);

        public Task<int> DelLibro(int idLibro);

    }
}
