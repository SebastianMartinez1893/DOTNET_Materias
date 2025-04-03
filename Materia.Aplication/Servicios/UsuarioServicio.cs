using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos;
using Materia.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace Materia.Aplication.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<Respuesta<bool>> IU_Usuario(Usuario datosUsuario)
        {

            var result = await _usuarioRepositorio.IU_Usuario(datosUsuario);
            return new Envoltorios.Respuesta<bool>()
            {
                CodigoEstado = result.Item1 ? HttpStatusCode.OK : HttpStatusCode.BadRequest,
                RespuestaEstado = result.Item1,
                Mensaje = result.Item2
            };
        }
    }
}
