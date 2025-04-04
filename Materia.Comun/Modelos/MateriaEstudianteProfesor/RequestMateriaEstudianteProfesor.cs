using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Comun.Modelos.MateriaEstudianteProfesor
{
    public class RequestMateriaEstudianteProfesor
    {
        public int IdMateriaProfesor { get; set; }
        public int IdUsuarioEstudiante { get; set; }
        public bool Activo { get; set; }
        public int Opcion { get; set; }
    }
}
