﻿using Materia.Comun.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Infraestructura.Interface
{
    public interface IUsuarioRepositorio
    {
        Task<(int, string)> IU_Usuario(Usuario usuario);
        Task<(bool, string, Usuario)> ValidarSesion(Usuario usuario);
    }
}
