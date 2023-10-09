using Prueba.Tecnica.Libreria.Entity.Genero;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Generos
{
    public interface IGeneroRepository
    {
        public Task<List<GeneroDTO>> GetAllGenerosAsync();

        public Task<GeneroDTO> AddGenero(GeneroDTO genero);
    }
}
