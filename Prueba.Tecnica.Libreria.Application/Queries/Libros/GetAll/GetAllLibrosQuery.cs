using MediatR;
using Prueba.Tecnica.Libreria.Entity.Autor;
using Prueba.Tecnica.Libreria.Entity.Libro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Queries.Libros.GetAll
{
    public class GetAllLibrosQuery : IRequest<List<LibroDTO>>
    {
    }
}
