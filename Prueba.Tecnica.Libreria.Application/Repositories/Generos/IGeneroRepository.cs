using Prueba.Tecnica.Libreria.Entity.Genero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Tecnica.Libreria.Application.Repositories.Generos
{
    public interface IGeneroRepository
    {
        public Task<List<GeneroDTO>> GetAllGenerosAsync();
    }
}
