using Materia.Aplication.Comandos;
using Materia.Aplication.Envoltorios;
using Materia.Comun.Modelos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Azure.Core.HttpHeader;

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
        public async Task<IActionResult> Insert([FromBody] RequestHandler request)
        {
            Respuesta<int> result = await Mediator.Send(request, new CancellationToken());
            return StatusCode(((int)HttpStatusCode.OK), result);
        }

        [HttpGet("ValidarSesion")]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Respuesta<long>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ValidarSesion([FromQuery] ValidacionUsuario request)
        {
            Respuesta<Materia.Comun.Modelos.Usuario> result = await Mediator.Send(request, new CancellationToken());
            return StatusCode(((int)HttpStatusCode.OK), result);
        }
    }
}
