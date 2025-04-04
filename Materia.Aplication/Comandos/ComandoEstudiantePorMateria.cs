using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos.MateriaEstudiante;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Comandos
{
    public class RequestEstudiantePorMateriaHandler : IRequest<Respuesta<List<ResponseMateriaEstudiante>>>
    {
        public int IdMateria { get; set; }
        public int IdUsuarioProfesor { get; set; }
    }
    public class ComandoEstudiantePorMateria : IRequestHandler<RequestEstudiantePorMateriaHandler, Respuesta<List<ResponseMateriaEstudiante>>>
    {
        private readonly IMateriaEstudianteServicio _materiaEstudianteServicio;
        public ComandoEstudiantePorMateria(IMateriaEstudianteServicio materiaEstudianteServicio)
        {
            _materiaEstudianteServicio = materiaEstudianteServicio;
        }

        public Task<Respuesta<List<ResponseMateriaEstudiante>>> Handle(RequestEstudiantePorMateriaHandler request, CancellationToken cancellationToken)
        {
            return _materiaEstudianteServicio.EstudiantePorMateria(new RequestMateriaEstudiante()
            {
                IdMateria = request.IdMateria,
                IdUsuarioProfesor = request.IdUsuarioProfesor,
            });
        }
    }
}
