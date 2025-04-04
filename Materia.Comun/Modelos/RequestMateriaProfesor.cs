using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Comun.Modelos
{
    public class RequestMateriaProfesor
    {
        public int IdMateria { get; set; }
        public int IdProfesor { get; set; }
        public bool Estado { get; set; }
        public int Opcion { get; set; }
    }
}
