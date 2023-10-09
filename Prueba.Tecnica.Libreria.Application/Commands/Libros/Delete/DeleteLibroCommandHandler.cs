using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Lirbos;

namespace Prueba.Tecnica.Libreria.Application.Commands.Libros.Delete
{
    public class DeleteLibroCommandHandler : IRequestHandler<DeleteLibroCommand, int>
    {
        private readonly ILibroRepository _libroRepository;

        public DeleteLibroCommandHandler(ILibroRepository libroRepository)
        {
            _libroRepository = libroRepository;
        }

        public async Task<int> Handle(DeleteLibroCommand command, CancellationToken cancellationToken)
        {
            return await _libroRepository.DelLibro(command.Id);

        }

    }
}
