using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Autores;
using Prueba.Tecnica.Libreria.Entity.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Commands.Autores.Add
{
    public class AddAutorCommandHandler : IRequestHandler<AddAutorCommand, AutorDTO>
    {
        private readonly IAutorRepository _autorRepository;

        public AddAutorCommandHandler(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<AutorDTO> Handle(AddAutorCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddAutorCommandValidator();
            ValidationResult results = validator.Validate(command);
            bool validationSucceeded = results.IsValid;
            if (!validationSucceeded)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
            }

            return await _autorRepository.AddAutor(new AutorDTO()
            {
                CiudadProcedencia = command.CiudadProcedencia,
                CorreoElectronico = command.CorreoElectronico,
                NombreCompleto = command.NombreCompleto,
                FechaNacimiento = command.FechaNacimiento
            });


        }
    }
}
