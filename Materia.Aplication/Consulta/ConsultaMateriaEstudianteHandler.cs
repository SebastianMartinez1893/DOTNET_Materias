using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos.MateriaEstudiante;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Consulta
{
    public class RequestMateriaEstudianteHandler: IRequest<Respuesta<List<ResponseMateriaEstudiante>>>
    {
        public int IdMateriaProfesor { get; set; }
    }
    public class ConsultaMateriaEstudianteHandler : IRequestHandler<RequestMateriaEstudianteHandler, Respuesta<List<ResponseMateriaEstudiante>>>
    {
        private readonly IMateriaEstudianteServicio _materiaEstudianteServicio;

        public ConsultaMateriaEstudianteHandler(IMateriaEstudianteServicio materiaEstudianteServicio)
        {
            _materiaEstudianteServicio = materiaEstudianteServicio;
        }

        public Task<Respuesta<List<ResponseMateriaEstudiante>>> Handle(RequestMateriaEstudianteHandler request, CancellationToken cancellationToken)
        {
            return _materiaEstudianteServicio.EstudiantePorMateria(request.IdMateriaProfesor);
        }
    }
}
