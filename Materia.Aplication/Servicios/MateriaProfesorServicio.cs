using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos;
using Materia.Infraestructura.Datos;
using Materia.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Servicios
{
    public class MateriaProfesorServicio : IMateriaProfesorServicio
    {
        private readonly IMateriaProfesorRepositorio _materiaProfesorRepositorio;

        public MateriaProfesorServicio(IMateriaProfesorRepositorio materiaProfesorRepositorio)
        {
            _materiaProfesorRepositorio = materiaProfesorRepositorio;
        }
        public async Task<Respuesta<List<ResponseMateriaProfesorDetalle>>> GetMateriaProfesor(RequestMateriaProfesor requestMateriaProfesor)
        {
            var returnDatos = await _materiaProfesorRepositorio.GetMateriasProfesor(requestMateriaProfesor);
            return new Respuesta<List<ResponseMateriaProfesorDetalle>>()
            {
                CodigoEstado = System.Net.HttpStatusCode.OK,
                Mensaje ="OK",
                Valores = returnDatos,
            };
        }
    }
}
