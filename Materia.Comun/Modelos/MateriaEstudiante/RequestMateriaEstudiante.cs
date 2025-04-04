using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Comun.Modelos.MateriaEstudiante
{
    public class RequestMateriaEstudiante
    {
        public int IdMateria { get; set; }
        public int IdUsuarioProfesor { get; set; }
    }
}
