using Materia.Aplication.Comandos;
using Materia.Aplication.Consulta;
using Materia.Aplication.Envoltorios;
using Materia.Comun.Modelos.MateriaEstudiante;
using Materia.Comun.Modelos.MateriaEstudianteProfesor;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Materias.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MateriaEstudiante : BaseController
    {
        [HttpPost("EstudiantePorMateria")]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEstudiantePorMateria([FromQuery] RequestEstudiantePorMateriaHandler request)
        {
            Respuesta<List<ResponseMateriaEstudiante>> result = await Mediator.Send(request, new CancellationToken());
            return StatusCode(((int)HttpStatusCode.OK), result);
        }


        [HttpPost("EstudianteMateriaProfesor")]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> EstudianteMateriaProfesor([FromBody] RequestMateriaEstudianteProfesorHandler request)
        {
            Respuesta<List<ResponseMateriaEstudianteProfesor>> result = await Mediator.Send(request, new CancellationToken());
            return StatusCode(((int)HttpStatusCode.OK), result);
        }

        [HttpGet("EstudianteMateria")]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEstudianteMateria([FromQuery] RequestMateriaEstudianteHandler request)
        {
            Respuesta<List<ResponseMateriaEstudiante>> result = await Mediator.Send(request, new CancellationToken());
            return StatusCode(((int)HttpStatusCode.OK), result);
        }
    }
}
