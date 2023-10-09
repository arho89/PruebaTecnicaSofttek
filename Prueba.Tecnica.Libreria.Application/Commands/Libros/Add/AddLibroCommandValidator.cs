using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Commands.Libros.Add
{
    public class AddLibroCommandValidator : AbstractValidator<AddLibroCommand>
    {
        public AddLibroCommandValidator()
        {
            
            RuleFor(p => p.titulo).NotNull().WithMessage("Nombre must be specifed")
                .NotEmpty().WithMessage("Password must be specifed");

            RuleFor(p => p.año).NotNull().WithMessage("año must be specifed")
                .NotEmpty().WithMessage("PortalId must be specifed");

            RuleFor(p => p.idGenero).NotNull().WithMessage("genero must be specifed")
                .NotEmpty().WithMessage("RoleId must be specifed");

            RuleFor(p => p.idAutor).NotNull().WithMessage("autor must be specifed")
                .NotEmpty().WithMessage("RoleId must be specifed");

            RuleFor(p => p.numeroPaginas).NotNull().WithMessage("paginas must be specifed")
                .NotEmpty().WithMessage("RoleId must be specifed");

        }
    }
}
