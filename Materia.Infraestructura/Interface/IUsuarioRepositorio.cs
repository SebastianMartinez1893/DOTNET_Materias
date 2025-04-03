using Materia.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Infraestructura.Interface
{
    public interface IUsuarioRepositorio
    {
       Task<(bool,string)> IU_Usuario(Usuario usuario);
    }
}
