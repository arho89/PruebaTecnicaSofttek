using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Generos;
using Prueba.Tecnica.Libreria.Entity.Genero;

namespace Prueba.Tecnica.Libreria.Application.Commands.Generos.Add
{
    public class AddGeneroCommandHandler : IRequestHandler<AddGeneroCommand, GeneroDTO>
    {
        private readonly IGeneroRepository _generoRepository;

        public AddGeneroCommandHandler(IGeneroRepository generoRepository)
        {
            _generoRepository = generoRepository;
        }
        public async Task<GeneroDTO> Handle(AddGeneroCommand command, CancellationToken cancellationToken)
        {

            return await _generoRepository.AddGenero(new GeneroDTO()
            {
                idGenero = command.idGenero,
                Nombre = command.Nombre
            });


        }
    }
}
