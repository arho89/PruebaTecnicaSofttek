using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Autores;
using Prueba.Tecnica.Libreria.Entity.Autor;

namespace Prueba.Tecnica.Libreria.Application.Queries.Autores.GetAll
{
    public class GetAllAutoresQueryHandler : IRequestHandler<GetAllAutoresQuery, List<AutorDTO>>
    {
        private readonly IAutorRepository _autorRepository;

        public GetAllAutoresQueryHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<List<AutorDTO>> Handle(GetAllAutoresQuery query, CancellationToken cancellationToken)
        {
            return await _autorRepository.GetAllAutorAsync();
        }
    }
}
