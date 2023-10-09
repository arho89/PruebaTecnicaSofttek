using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prueba.Tecnica.Libreria.Application.Commands.Libros.Add;
using Prueba.Tecnica.Libreria.Application.Queries.Libros.GetAll;
using Prueba.Tecnica.Libreria.Entity.Libro;

namespace Prueba.Tecnica.Libreria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        public LibrosController (IMediator mediator, IConfiguration configuration)
        {
            _mediator = mediator;
            _configuration = configuration;
        }

        // GET: api/<AutoresController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<LibroDTO>))]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllLibrosQuery());
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST api/<redarborController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LibroDTO libroDTO)
        {
            try
            {
                return Ok(await _mediator.Send(new AddLibroCommand()
                {
                    idGenero = libroDTO.idGenero,
                    numeroPaginas = libroDTO.numeroPaginas,
                    titulo = libroDTO.titulo,
                    año = libroDTO.año,
                    idAutor = libroDTO.idAutor,
                    cantidadDeLibrosPermitidos = _configuration.GetValue<int>("LibrosPermitidos")
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
