using Materia.Aplication.Envoltorios;
using Materia.Comun.Modelos.MateriaEstudiante;
using Materia.Comun.Modelos.MateriaEstudianteProfesor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Interfaces
{
    public interface IMateriaEstudianteServicio
    {
        public Task<Respuesta<List<ResponseMateriaEstudiante>>> EstudiantePorMateria(RequestMateriaEstudiante requestMateriaEstudiante);
        Task<Respuesta<List<ResponseMateriaEstudianteProfesor>>> GIU_MateriaEstudianteProfesor(RequestMateriaEstudianteProfesor requestMateriaEstudiante);
    }
}
