using MediatR;
using Prueba.Tecnica.Libreria.Entity.Autor;

namespace Prueba.Tecnica.Libreria.Application.Queries.Autores.GetAll
{
    public class GetAllAutoresQuery : IRequest<List<AutorDTO>>
    {
    }
}
