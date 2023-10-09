using MediatR;
using Prueba.Tecnica.Libreria.Entity.Libro;

namespace Prueba.Tecnica.Libreria.Application.Queries.Libros.GetAll
{
    public class GetAllLibrosQuery : IRequest<List<LibroDTO>>
    {
    }
}
