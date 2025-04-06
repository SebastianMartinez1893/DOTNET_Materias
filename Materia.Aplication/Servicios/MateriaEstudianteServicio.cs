using Materia.Aplication.Envoltorios;
using Materia.Aplication.Interfaces;
using Materia.Comun.Modelos.MateriaEstudiante;
using Materia.Comun.Modelos.MateriaEstudianteProfesor;
using Materia.Infraestructura.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Servicios
{
    public class MateriaEstudianteServicio : IMateriaEstudianteServicio
    {
        private readonly IMateriaEstudianteRepositorio _materiaEstudianteRepositorio;
        public MateriaEstudianteServicio(IMateriaEstudianteRepositorio materiaEstudianteRepositorio)
        {
            _materiaEstudianteRepositorio = materiaEstudianteRepositorio;
        }

        public async Task<Respuesta<List<ResponseMateriaEstudiante>>> EstudiantePorMateria(RequestMateriaEstudiante requestMateriaEstudiante)
        {
            var Ret = await _materiaEstudianteRepositorio.ListEstudiantesPorMateria(requestMateriaEstudiante);
            return new Respuesta<List<ResponseMateriaEstudiante>>()
            {
                CodigoEstado = System.Net.HttpStatusCode.OK,
                Valores = Ret,
            };
        }

        public async Task<Respuesta<List<ResponseMateriaEstudianteProfesor>>> GIU_MateriaEstudianteProfesor(RequestMateriaEstudianteProfesor requestMateriaEstudiante)
        {
            var ret = await _materiaEstudianteRepositorio.GIU_MateriaestudianteProfesor(requestMateriaEstudiante);
            return new Respuesta<List<ResponseMateriaEstudianteProfesor>>()
            {
                CodigoEstado = System.Net.HttpStatusCode.OK,
                Valores = ret
            };
        }
        public async Task<Respuesta<List<ResponseMateriaEstudiante>>> EstudiantePorMateria(long IdMateriaProfesor)
        {
            var Ret = await _materiaEstudianteRepositorio.G_EstudiantePorMateria(IdMateriaProfesor);
            return new Respuesta<List<ResponseMateriaEstudiante>>()
            {
                CodigoEstado = System.Net.HttpStatusCode.OK,
                Valores = Ret,
            };
        }
    }
}
