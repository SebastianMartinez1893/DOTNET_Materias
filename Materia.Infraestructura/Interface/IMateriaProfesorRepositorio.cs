using Materia.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Infraestructura.Interface
{
    public interface IMateriaProfesorRepositorio
    {
        Task<List<ResponseMateriaProfesorDetalle>> GetMateriasProfesor(RequestMateriaProfesor requestMateria);
    }
}
