using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Lirbos;
using Prueba.Tecnica.Libreria.Entity.Libro;
using System.Text;

namespace Prueba.Tecnica.Libreria.Application.Commands.Libros.Add
{
    public class AddLibroCommandHandler : IRequestHandler<AddLibroCommand, LibroDTO>
    {
        private readonly ILibroRepository _libroRepository;

        public AddLibroCommandHandler(ILibroRepository libroRepository)
        { 
            _libroRepository = libroRepository;
        }

        public async Task<LibroDTO> Handle(AddLibroCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddLibroCommandValidator();
            ValidationResult results = validator.Validate(command);
            bool validationSucceeded = results.IsValid;
            if (!validationSucceeded)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
            }

            return await _libroRepository.AddLibro(new LibroDTO()
            {
                titulo = command.titulo,
                idAutor = command.idAutor,
                año = command.año,
                numeroPaginas = command.numeroPaginas,
                idGenero = command.idGenero
            }, command.cantidadDeLibrosPermitidos);


        }
    }
}
