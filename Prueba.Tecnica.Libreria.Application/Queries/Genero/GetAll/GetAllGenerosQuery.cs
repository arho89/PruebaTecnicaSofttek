using MediatR;
using Prueba.Tecnica.Libreria.Entity.Genero;

namespace Prueba.Tecnica.Libreria.Application.Queries.Genero.GetAll
{
    public class GetAllGenerosQuery : IRequest<List<GeneroDTO>>
    {
    }
}
