﻿using Materia.Aplication.Envoltorios;
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
        Task<Respuesta<int>> IU_Usuario(Usuario datosUsuario);
        Task<Respuesta<Usuario>> ValidarSesion(Usuario datosUsuario);
    }
}
