
using Microsoft.EntityFrameworkCore;
using Prueba.Tecnica.Libreria.Application.Repositories.Autores;
using Prueba.Tecnica.Libreria.DataAccess.Persistence;
using Prueba.Tecnica.Libreria.Entity.Libro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Lirbos
{
    public class LibroRepository : ILibroRepository
    {
        private readonly LibreriaContext _context;


        public LibroRepository(LibreriaContext context)
        {
            _context = context;
        }

        public async Task<List<LibroDTO>> GetAllLibrosAsync()
        {
            var libros = await _context.Libros.ToListAsync();
            if (libros == null)
                return null;

            var results = new List<LibroDTO>();
            foreach (var p in libros)
            {
                var libroDisplay = new LibroDTO
                {
                    autor = _context.Autors.Where(x => x.Id == p.IdAutor).FirstOrDefault().NombreCompleto,
                    año = p.Año,
                    genero = _context.Generos.Where(x => x.Id == p.IdGenero).FirstOrDefault().Nombre,
                    id = p.Id,
                    idAutor = p.IdAutor,
                    idGenero = p.IdGenero,
                    numeroPaginas = p.NumeroPaginas,
                    titulo = p.Titulo
                };
                results.Add(libroDisplay);
            }
            return results;
        }

        public async Task<LibroDTO> AddLibro(LibroDTO libro, int cantidadLibrosPermitidos)
        {
            var LibroDB = await _context.Libros.Where(x => x.Titulo == libro.titulo).FirstOrDefaultAsync();
            var _genero = await _context.Generos.Where(x => x.Id == libro.idGenero).FirstOrDefaultAsync();
            var _autor = await _context.Autors.Where(x => x.Id == libro.idAutor).FirstOrDefaultAsync();

            var cantLibros = await _context.Libros.CountAsync();

            if (cantLibros >= cantidadLibrosPermitidos)
                throw new ValidationException("Canitidad de libros Permitidos superado");
            if (LibroDB != null)
                throw new ValidationException("The Libro" + LibroDB.Titulo + " already exists in the database");
            if (_genero == null)
                throw new ValidationException("The Genero doesn't exists in the database");

            if (_autor == null)
                throw new ValidationException("The Autor doesn't exists in the database");

            libro.genero = _genero.Nombre;
            libro.autor = _autor.NombreCompleto;

            var newLibro = new Libro
            {
                Titulo = libro.titulo,
                NumeroPaginas = libro.numeroPaginas,
                Año = libro.año,
                FechaCreacion = DateTime.Now,
                IdAutor = libro.idAutor,
                IdGenero = libro.idGenero,

            };

            _context.Libros.Add(newLibro);
            await _context.SaveChangesAsync();
            return libro;

        }

    }
}