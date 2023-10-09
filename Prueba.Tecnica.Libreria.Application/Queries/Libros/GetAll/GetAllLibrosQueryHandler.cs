using MediatR;
using Prueba.Tecnica.Libreria.Application.Queries.Autores.GetAll;
using Prueba.Tecnica.Libreria.Application.Repositories.Lirbos;
using Prueba.Tecnica.Libreria.Entity.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Queries.Libros.GetAll
{
    public class GetAllLibrosQueryHandler : IRequestHandler<GetAllLibrosQuery, List<LibroDTO>>
    {
        private readonly ILibroRepository _libroRepository;

        public GetAllLibrosQueryHandler(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }
        public async Task<List<LibroDTO>> Handle(GetAllLibrosQuery query, CancellationToken cancellationToken)
        {
            return await _libroRepository.GetAllLibrosAsync();
        }
    }
}
