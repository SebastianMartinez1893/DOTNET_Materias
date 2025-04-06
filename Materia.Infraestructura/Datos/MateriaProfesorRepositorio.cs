using Materia.Comun.Modelos;
using Materia.Infraestructura.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Infraestructura.Datos
{
    public class MateriaProfesorRepositorio : IMateriaProfesorRepositorio
    {
        private readonly string cadenaConexion;
        public MateriaProfesorRepositorio(string connectionString)
        {
            cadenaConexion = connectionString;
        }

        public async Task<List<ResponseMateriaProfesorDetalle>> GetMateriasProfesor(RequestMateriaProfesor requestMateria)
        {
            List<ResponseMateriaProfesorDetalle> ListMateriaProfesor = new();
            try
            {
                using SqlConnection connection = new(cadenaConexion);
                using SqlCommand command = new("GIU_MateriaProfesor", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@IdMateria", requestMateria.IdMateria);
                command.Parameters.AddWithValue("@IdProfesor", requestMateria.IdProfesor);
                command.Parameters.AddWithValue("@Estado", requestMateria.Estado);
                command.Parameters.AddWithValue("@Opcion", requestMateria.Opcion);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                while (reader.Read())
                {
                    ResponseMateriaProfesorDetalle profesorDetalle = new()
                    {
                        IdMateria = Convert.ToInt32(reader["IdMateria"]),
                        Materia = reader["Materia"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        IdProfesor = reader["IdProfesor"] == DBNull.Value ? 0 : Convert.ToInt32(reader["IdProfesor"]),
                        NombreDocente = reader["NombreDocente"].ToString()
                    };
                    ListMateriaProfesor.Add(profesorDetalle);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener las materias: {ex.Message}", ex);
            }
            return ListMateriaProfesor;

        }
    }
}
