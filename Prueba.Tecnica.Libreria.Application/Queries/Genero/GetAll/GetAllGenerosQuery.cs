using MediatR;
using Prueba.Tecnica.Libreria.Entity.Genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Queries.Genero.GetAll
{
    public class GetAllGenerosQuery : IRequest<List<GeneroDTO>>
    {
    }
}
