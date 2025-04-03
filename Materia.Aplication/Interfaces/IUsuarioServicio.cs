using Materia.Aplication.Envoltorios;
using Materia.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<Respuesta<bool>> IU_Usuario(Usuario datosUsuario);
    }
}
