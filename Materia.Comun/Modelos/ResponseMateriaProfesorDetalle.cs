using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Comun.Modelos
{
    public class ResponseMateriaProfesorDetalle
    {
        public long IdMateria { get; set; }
        public string? Materia { get; set; }
        public string? Estado { get; set; }
        public string? NombreDocente { get; set; }
    }
}
