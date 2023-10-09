using FluentValidation;

namespace Prueba.Tecnica.Libreria.Application.Commands.Libros.Add
{
    public class AddLibroCommandValidator : AbstractValidator<AddLibroCommand>
    {
        public AddLibroCommandValidator()
        {
            
            RuleFor(p => p.titulo).NotNull().WithMessage("Titulo debe ser especificado")
                .NotEmpty().WithMessage("Titulo debe ser especificado");

            RuleFor(p => p.año).NotNull().WithMessage("año debe ser especificado")
                .NotEmpty().WithMessage("año debe ser especificado");

            RuleFor(p => p.idGenero).NotNull().WithMessage("genero debe ser especificado")
                .NotEmpty().WithMessage("genero debe ser especificado");

            RuleFor(p => p.idAutor).NotNull().WithMessage("autor debe ser especificado")
                .NotEmpty().WithMessage("autor debe ser especificado");

            RuleFor(p => p.numeroPaginas).NotNull().WithMessage("paginas debe ser especificado")
                .NotEmpty().WithMessage("paginas debe ser especificado");

        }
    }
}
