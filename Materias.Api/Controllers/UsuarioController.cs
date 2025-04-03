using Materia.Aplication.Comandos;
using Materia.Aplication.Envoltorios;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Materias.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        [HttpPost("InsertarUsuario")]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Insert([FromBody] Usuario request)
        {
            Respuesta<bool> result = await Mediator.Send(request, new CancellationToken());

            return StatusCode(((int)result.CodigoEstado), result);
        }
    }
}
