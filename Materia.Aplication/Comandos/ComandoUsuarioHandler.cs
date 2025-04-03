using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Comandos
{
    public class Usuario : IRequest<Respuesta<bool>>
    {
        public long identificiacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? celular { get; set; }
        public string? password { get; set; }
    }

    public class ComandoUsuarioHandler : IRequestHandler<Usuario, Respuesta<bool>>
    {
        private readonly IUsuarioServicio _usuarioServicio;
        public ComandoUsuarioHandler(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }
        public Task<Respuesta<bool>> Handle(Usuario request, CancellationToken cancellationToken)
        {
            return _usuarioServicio.IU_Usuario(new Comun.Modelos.Usuario()
            {
                identificiacion = request.identificiacion,
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                Email = request.Email,
                celular = request.celular,
                password = request.password
            });
        }
    }
}
