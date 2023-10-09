using MediatR;

namespace Prueba.Tecnica.Libreria.Application.Commands.Libros.Delete
{
    public class DeleteLibroCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
