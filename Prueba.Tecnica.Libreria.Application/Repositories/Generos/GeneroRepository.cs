using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Prueba.Tecnica.Libreria.DataAccess.Persistence;
using Prueba.Tecnica.Libreria.Entity.Genero;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Generos
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly LibreriaContext _context;

        public GeneroRepository(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<List<GeneroDTO>> GetAllGenerosAsync()
        {
            var generos = await _context.Generos.ToListAsync();
            if (generos == null)
                return null;

            var results = new List<GeneroDTO>();
            foreach (var p in generos)
            {
                var autorDisplay = new GeneroDTO
                {
                    idGenero = p.Id,
                    Nombre = p.Nombre
                };
                results.Add(autorDisplay);
            }
            return results;

        }

        public async Task<GeneroDTO> AddGenero(GeneroDTO genero)
        {

            var _genero = await _context.Generos.Where(x => x.Nombre == genero.Nombre).FirstOrDefaultAsync();


            if (_genero != null)
                throw new ValidationException("genero" + genero.Nombre + " ya existe en la base de datos");
            
            var newGenero = new Genero
            {
                FechaCreacion = DateTime.Now,
                Nombre = genero.Nombre
            };

            _context.Generos.Add(newGenero);
            await _context.SaveChangesAsync();
            return genero;

        }

    }
}
