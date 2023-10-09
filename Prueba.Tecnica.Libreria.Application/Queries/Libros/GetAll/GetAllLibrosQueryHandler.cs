using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Lirbos;
using Prueba.Tecnica.Libreria.Entity.Libro;


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
