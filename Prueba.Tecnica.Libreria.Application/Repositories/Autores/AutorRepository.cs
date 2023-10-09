using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Prueba.Tecnica.Libreria.DataAccess.Persistence;
using Prueba.Tecnica.Libreria.Entity.Autor;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Autores
{
    public class AutorRepository : IAutorRepository
    {
        private readonly LibreriaContext _context;

        public AutorRepository(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<List<AutorDTO>> GetAllAutorAsync()
        {
            var autor = await _context.Autors.ToListAsync();
            if (autor == null)
                return null;

            var results = new List<AutorDTO>();
            foreach (var p in autor)
            {
                var autorDisplay = new AutorDTO
                {
                    idAutor= p.Id,
                    CiudadProcedencia=p.CiudadProcedencia,
                    CorreoElectronico=p.CorreoElectronico,
                    FechaNacimiento = p.FechaNacimiento,
                    NombreCompleto = p.NombreCompleto
                };
                results.Add(autorDisplay);
            }
            return results;
        }

        public async Task<AutorDTO> AddAutor(AutorDTO autor) 
        {
            var autorDB = await _context.Autors.Where(x => x.NombreCompleto == autor.NombreCompleto).FirstOrDefaultAsync();
            if (autorDB != null)
                throw new ValidationException("El Autor ya existe en la base de datos");

            var newAutor = new Autor
            {
                NombreCompleto = autor.NombreCompleto,
                CiudadProcedencia = autor.CiudadProcedencia,
                CorreoElectronico = autor.CorreoElectronico,
                FechaNacimiento =Convert.ToDateTime(autor.FechaNacimiento),
                FechaCreacion = DateTime.Now

            };

            _context.Autors.Add(newAutor);
            await _context.SaveChangesAsync();
            return autor;
        }
    }
}
