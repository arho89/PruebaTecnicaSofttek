using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prueba.Tecnica.Libreria.Application.Commands.Generos.Add;
using Prueba.Tecnica.Libreria.Application.Queries.Genero.GetAll;
using Prueba.Tecnica.Libreria.Entity.Genero;

namespace Prueba.Tecnica.Libreria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : Controller
    {
        private readonly IMediator _mediator;

        public GenerosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Generos
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GeneroDTO>))]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllGenerosQuery());
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST api/Generos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GeneroDTO generoDTO)
        {
            try
            {
                return Ok(await _mediator.Send(new AddGeneroCommand()
                {
                    idGenero = generoDTO.idGenero,
                    Nombre = generoDTO.Nombre

                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
