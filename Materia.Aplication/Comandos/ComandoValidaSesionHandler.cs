using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Comandos
{
    public class ValidacionUsuario : IRequest<Respuesta<Comun.Modelos.Usuario>>
    {
        public string? email { get; set; }
        public string? password { get; set; }
    }
    public class ComandoValidaSesionHandler : IRequestHandler<ValidacionUsuario, Respuesta<Comun.Modelos.Usuario>>
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public ComandoValidaSesionHandler(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        Task<Respuesta<Comun.Modelos.Usuario>> IRequestHandler<ValidacionUsuario, Respuesta<Comun.Modelos.Usuario>>.Handle(ValidacionUsuario request, CancellationToken cancellationToken)
        {
            return  _usuarioServicio.ValidarSesion(new Comun.Modelos.Usuario()
            {
                Email = request.email, 
                password = request.password,
            });
        }
    }
}
