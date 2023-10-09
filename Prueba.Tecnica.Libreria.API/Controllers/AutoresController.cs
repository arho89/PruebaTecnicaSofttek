using MediatR;
using Microsoft.AspNetCore.Mvc;
using Prueba.Tecnica.Libreria.Application.Commands.Autores.Add;
using Prueba.Tecnica.Libreria.Application.Queries.Autores.GetAll;
using Prueba.Tecnica.Libreria.Entity.Autor;

namespace Prueba.Tecnica.Libreria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : Controller
    {

        private readonly IMediator _mediator;
        public AutoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AutoresController>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<AutorDTO>))]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllAutoresQuery());
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        // POST api/<redarborController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AutorDTO autorDTO)
        {
            try
            {
                return Ok(await _mediator.Send(new AddAutorCommand()
                {
                    CiudadProcedencia = autorDTO.CiudadProcedencia,
                    CorreoElectronico = autorDTO.CorreoElectronico,
                    NombreCompleto = autorDTO.NombreCompleto,
                    FechaNacimiento = autorDTO.FechaNacimiento
                    
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

    }
}
