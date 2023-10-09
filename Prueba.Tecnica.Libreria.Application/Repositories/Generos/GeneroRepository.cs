using Microsoft.EntityFrameworkCore;
using Prueba.Tecnica.Libreria.DataAccess.Persistence;
using Prueba.Tecnica.Libreria.Entity.Genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
