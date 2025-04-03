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

        public async Task<(bool, string)> IU_Usuario(Usuario usuario)
        {
            try
            {
                using SqlConnection connection = new(cadenaConexion);
                using SqlCommand command = new("IU_Usuario", connection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.AddWithValue("@Identificacion", usuario.identificiacion);
                command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Celular", usuario.celular);
                command.Parameters.AddWithValue("@Password", usuario.password);
                await connection.OpenAsync();
                SqlDataReader reader = await command.ExecuteReaderAsync();
                (bool, string) response = (false,string.Empty);
                if (reader.Read())
                {
                    int val = Convert.ToInt32(reader[0]);
                   
                    if (val == 1)
                    {
                        response =  (true, $"¡Se guardó exitosamente el usuario!");
                    }
                    else if(val ==2)
                    {
                        response = (true, $"¡Ya existe el usuario!");
                    }
                    else
                    {
                        response = (false, $"¡No se guardó el usuario!");
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}
