using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos;
using Materia.Seguridad;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Comandos
{
    public class RequestHandler : IRequest<Respuesta<int>>
    {
        public string request { get; set; }
    }
    public class BodyHandler
    {
        public Usuario? body { get; set; }
    }

    public class ComandoUsuarioHandler : IRequestHandler<RequestHandler, Respuesta<int>>
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public ComandoUsuarioHandler(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public Task<Respuesta<int>> Handle(RequestHandler request, CancellationToken cancellationToken)
        {
            EncripcionAES encrypt = new();
            Usuario datos = JsonConvert.DeserializeObject<BodyHandler>(encrypt.Decrypt(request.request)).body;
            return _usuarioServicio.IU_Usuario(new Usuario()
            {
                identificacion = datos.identificacion,
                Nombre = datos.Nombre,
                Apellido = datos.Apellido,
                Email = datos.Email,
                celular = datos.celular,
                password = datos.password,
                rolId = datos.rolId
            });
        }

        
    }
}
