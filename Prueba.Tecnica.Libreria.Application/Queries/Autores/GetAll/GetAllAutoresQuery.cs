﻿using MediatR;
using Prueba.Tecnica.Libreria.Application.Repositories.Autores;
using Prueba.Tecnica.Libreria.Entity.Autor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Queries.Autores.GetAll
{
    public class GetAllAutoresQuery : IRequest<List<AutorDTO>>
    {
    }
}
