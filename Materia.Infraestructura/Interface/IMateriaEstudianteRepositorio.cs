using Materia.Comun.Modelos.MateriaEstudiante;
using Materia.Comun.Modelos.MateriaEstudianteProfesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Infraestructura.Interface
{
    public interface IMateriaEstudianteRepositorio
    {
        Task<List<ResponseMateriaEstudiante>> ListEstudiantesPorMateria(RequestMateriaEstudiante materiaEstudiante);

        Task<List<ResponseMateriaEstudianteProfesor>> GIU_MateriaestudianteProfesor(RequestMateriaEstudianteProfesor requestMateriaEstudiante);
    }
}
