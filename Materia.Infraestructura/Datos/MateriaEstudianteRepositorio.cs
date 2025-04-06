using Materia.Comun.Modelos;
using Materia.Comun.Modelos.MateriaEstudiante;
using Materia.Comun.Modelos.MateriaEstudianteProfesor;
using Materia.Infraestructura.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Infraestructura.Datos
{
    public class MateriaEstudianteRepositorio : IMateriaEstudianteRepositorio
    {
        private readonly string cadenaConexion;
        public MateriaEstudianteRepositorio(string connectionString)
        {
            cadenaConexion = connectionString;
        }
        public async Task<List<ResponseMateriaEstudiante>> ListEstudiantesPorMateria(RequestMateriaEstudiante materiaEstudiante)
        {
            List<ResponseMateriaEstudiante> ListEstudiantesXProfesor = [];
            try
            {
                using SqlConnection connection = new(cadenaConexion);
                using SqlCommand command = new("GIU_MateriaEstudiante", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@IdMateria", materiaEstudiante.IdMateria);
                command.Parameters.AddWithValue("@IdProfesor", materiaEstudiante.IdUsuarioProfesor);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    ResponseMateriaEstudiante MateriaDetalle = new()
                    {
                         NombreEstudiante = reader["NombreEstudiante"].ToString()
                    };
                    ListEstudiantesXProfesor.Add(MateriaDetalle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los estudiantes por Materia: {ex.Message}", ex);
            }
            return ListEstudiantesXProfesor;
        }

        public async Task<List<ResponseMateriaEstudianteProfesor>> GIU_MateriaestudianteProfesor(RequestMateriaEstudianteProfesor requestMateriaEstudiante)
        {
            List<ResponseMateriaEstudianteProfesor> ListEstudiantesXProfesor = [];
            try
            {
                using SqlConnection connection = new(cadenaConexion);
                using SqlCommand command = new("GIU_MateriaProfesorEstudiante", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@IdMateriaProfesor", requestMateriaEstudiante.IdMateriaProfesor);
                command.Parameters.AddWithValue("@IdUsuarioEstudiante", requestMateriaEstudiante.IdUsuarioEstudiante);
                command.Parameters.AddWithValue("@Activo", requestMateriaEstudiante.Activo);
                command.Parameters.AddWithValue("@Opcion", requestMateriaEstudiante.Opcion);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    ResponseMateriaEstudianteProfesor MateriaDetalle = new()
                    {
                        IdMateriaProfesor = Convert.ToInt32(reader["IdMateria"]),
                        Materia = reader["Materia"].ToString(),
                        NombreDocente = reader["NombreDocente"].ToString(),
                        IdProfesor = Convert.ToInt32(reader["IdProfesor"]),
                        EstadoAsignacion = reader["EstadoAsignacion"].ToString(),
                    };
                    ListEstudiantesXProfesor.Add(MateriaDetalle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las materias reservadas: {ex.Message}", ex);
            }
            return ListEstudiantesXProfesor;
        }

        public async Task<List<ResponseMateriaEstudiante>> G_EstudiantePorMateria(long IdMateriaProfesor)
        {
            List<ResponseMateriaEstudiante> ListEstudiantesXProfesor = [];
            try
            {
                using SqlConnection connection = new(cadenaConexion);
                using SqlCommand command = new("G_EstudiantePorMateria", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@IdMateriaProfesor", IdMateriaProfesor);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    ResponseMateriaEstudiante MateriaDetalle = new()
                    {
                        NombreEstudiante = reader["NombreEstudiante"].ToString()
                    };
                    ListEstudiantesXProfesor.Add(MateriaDetalle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los estudiantes por Materia: {ex.Message}", ex);
            }
            return ListEstudiantesXProfesor;
        }
    }
}
