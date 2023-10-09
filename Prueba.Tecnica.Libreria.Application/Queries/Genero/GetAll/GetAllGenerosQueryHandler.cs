using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Generos;
using Prueba.Tecnica.Libreria.Entity.Genero;

namespace Prueba.Tecnica.Libreria.Application.Queries.Genero.GetAll
{
    public class GetAllGenerosQueryHandler : IRequestHandler<GetAllGenerosQuery, List<GeneroDTO>>
    {
        private readonly IGeneroRepository _generoRepository;

        public GetAllGenerosQueryHandler(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        public async Task<List<GeneroDTO>> Handle(GetAllGenerosQuery query, CancellationToken cancellationToken)
        {
            return await _generoRepository.GetAllGenerosAsync();
        }
    }
}
