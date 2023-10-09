using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Commands.Autores.Add
{
    public class AddAutorCommandValidator : AbstractValidator<AddAutorCommand>
    {
        public AddAutorCommandValidator()
        {

            RuleFor(p => p.CorreoElectronico).NotNull().WithMessage("Email must be specifed")
                .NotEmpty().WithMessage("Email must be specifed")
                .EmailAddress().WithMessage("Email must be valid");

            RuleFor(p => p.NombreCompleto).NotNull().WithMessage("Nombre must be specifed")
                .NotEmpty().WithMessage("Password must be specifed");

            RuleFor(p => p.CiudadProcedencia).NotNull().WithMessage("Ciudad must be specifed")
                .NotEmpty().WithMessage("PortalId must be specifed");

            RuleFor(p => p.FechaNacimiento).NotNull().WithMessage("Fecha Nacimiento must be specifed")
                .NotEmpty().WithMessage("RoleId must be specifed");

        }
    }
}
