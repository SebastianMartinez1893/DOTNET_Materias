using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Comun.Modelos.MateriaEstudianteProfesor
{
    public class ResponseMateriaEstudianteProfesor
    {
        public int IdMateriaProfesor { get; set; }
        public string? Materia { get; set; }
        public string? NombreDocente { get; set; }
        public string? EstadoAsignacion { get; set; }
    }
}
