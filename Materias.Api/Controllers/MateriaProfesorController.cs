using Materia.Aplication.Envoltorios;
using Materia.Comun.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Materias.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaProfesorController : BaseController
    {
        [HttpPost("ObtenerMateriasProfesor")]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> obtenerMaterias([FromBody] Materia.Aplication.Comandos.RequestMateriaProfesorHandler request)
        {
            Respuesta<List<ResponseMateriaProfesorDetalle>> result = await Mediator.Send(request, new CancellationToken());

            return StatusCode(((int)HttpStatusCode.OK), result);
        }
    }
}
