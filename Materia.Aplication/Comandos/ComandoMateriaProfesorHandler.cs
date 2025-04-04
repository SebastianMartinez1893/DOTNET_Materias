using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Comandos
{
    public class RequestMateriaProfesorHandler : IRequest<Respuesta<List<ResponseMateriaProfesorDetalle>>>
    {
        public int IdMateria { get; set; }
        public int IdProfesor { get; set; }
        public bool Estado { get; set; }
        public int Opcion { get; set; }
    }
    public class ComandoMateriaProfesorHandler : IRequestHandler<RequestMateriaProfesorHandler, Respuesta<List<ResponseMateriaProfesorDetalle>>>
    {
        private readonly IMateriaProfesorServicio _materiaProfesorServicio;
        public ComandoMateriaProfesorHandler(IMateriaProfesorServicio materiaProfesorServicio)
        {
            _materiaProfesorServicio = materiaProfesorServicio;
        }
        public Task<Respuesta<List<ResponseMateriaProfesorDetalle>>> Handle(RequestMateriaProfesorHandler request, CancellationToken cancellationToken)
        {
            return _materiaProfesorServicio.GetMateriaProfesor(new RequestMateriaProfesor()
            { 
                IdMateria = request.IdMateria,
                Estado = request.Estado, 
                IdProfesor = request.IdProfesor,
                Opcion = request.Opcion
            });
            
        }
    }
}
