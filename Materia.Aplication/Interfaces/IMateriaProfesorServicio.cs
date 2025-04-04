using Materia.Aplication.Envoltorios;
using Materia.Comun.Modelos;
using Materia.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Interfaces
{
    public interface IMateriaProfesorServicio
    {
        Task<Respuesta<List<ResponseMateriaProfesorDetalle>>> GetMateriaProfesor(RequestMateriaProfesor requestMateriaProfesor);
    }
}
