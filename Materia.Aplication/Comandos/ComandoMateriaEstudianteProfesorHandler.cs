using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos.MateriaEstudianteProfesor;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Comandos
{
    public class RequestMateriaEstudianteProfesorHandler : IRequest<Respuesta<List<ResponseMateriaEstudianteProfesor>>>
    {
        public int IdMateriaProfesor { get; set; }
        public int IdUsuarioEstudiante { get; set; }
        public bool Activo { get; set; }
        public int Opcion { get; set; }
    }
    public class ComandoMateriaEstudianteProfesorHandler : IRequestHandler<RequestMateriaEstudianteProfesorHandler, Respuesta<List<ResponseMateriaEstudianteProfesor>>>
    {
        private readonly IMateriaEstudianteServicio _materiaEstudianteServicio;
        public ComandoMateriaEstudianteProfesorHandler(IMateriaEstudianteServicio materiaEstudianteServicio)
        {
            _materiaEstudianteServicio = materiaEstudianteServicio;
        }

        public Task<Respuesta<List<ResponseMateriaEstudianteProfesor>>> Handle(RequestMateriaEstudianteProfesorHandler request, CancellationToken cancellationToken)
        {
            return _materiaEstudianteServicio.GIU_MateriaEstudianteProfesor(new RequestMateriaEstudianteProfesor()
            {
                Opcion = request.Opcion,
                Activo = request.Activo,    
                IdMateriaProfesor  = request.IdMateriaProfesor,
                IdUsuarioEstudiante = request.IdUsuarioEstudiante
            });
        }
    }
}
