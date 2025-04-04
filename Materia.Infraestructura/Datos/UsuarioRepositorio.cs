using Azure;
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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly string cadenaConexion;
        public UsuarioRepositorio(string connectionString)
        {
            cadenaConexion = connectionString;
        }

        public async Task<(int, string)> IU_Usuario(Usuario usuario)
        {
            try
            {
                using SqlConnection connection = new(cadenaConexion);
                using SqlCommand command = new("IU_Usuario", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Identificacion", usuario.identificacion);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Celular", usuario.celular);
                command.Parameters.AddWithValue("@Password", usuario.password);
                command.Parameters.AddWithValue("@RolId", usuario.rolId);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                (int, string) response = (0, string.Empty);
                if (reader.Read())
                {
                    int val = Convert.ToInt32(reader[0]);

                    if (val != -1)
                    {
                        response = (val, $"¡Se guardó exitosamente el usuario!");
                    }
                    else if (val == -1)
                    {
                        response = (-1, $"¡Ya existe el usuario!");
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return (-1, ex.Message);
            }
        }

        public async Task<(bool,string, Usuario)> ValidarSesion(Usuario usuario)
        {
            try
            {
                using SqlConnection connection = new(cadenaConexion);
                using SqlCommand command = new("G_ValidarUsuario", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Password", usuario.password);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                (bool, string, Usuario?) response = (false, string.Empty, new Usuario());
                if (reader.Read())
                {
                    Usuario DatosUsuario = new();
                    DatosUsuario.Nombre = reader["USU_Nombre"].ToString();
                    DatosUsuario.idUsuario = Convert.ToInt32(reader["USU_IdUsuario"]);
                    DatosUsuario.rolId = Convert.ToInt32(reader["ROL_IdRol"]);
                    response = (true, "",DatosUsuario);
                }
                else
                {
                    response = (false, $"¡Datos inválidos, por favor validar!",null);
                }
                return response;
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null);
            }
        }
    }
}
