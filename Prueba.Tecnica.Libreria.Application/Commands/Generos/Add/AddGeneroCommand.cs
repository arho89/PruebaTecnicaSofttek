using MediatR;
using Prueba.Tecnica.Libreria.Entity.Genero;


namespace Prueba.Tecnica.Libreria.Application.Commands.Generos.Add
{
    public class AddGeneroCommand : IRequest<GeneroDTO>
    {
        public int idGenero { get; set; }

        public string Nombre { get; set; }
    }
}
