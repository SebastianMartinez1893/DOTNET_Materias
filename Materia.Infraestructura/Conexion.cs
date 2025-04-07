using Materia.Seguridad;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Materia.Infraestructura
{
    public class Conexion
    {

        private IConfiguration configroot;
        public Conexion(IConfiguration _configroot)
        {
            configroot = _configroot;
        }

        public string ObtenerDatosConexion()
        {
            IEnumerable<IConfigurationSection> data = configroot.GetSection("Conexion").GetChildren();
            EncripcionAES encripcion = new();
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = encripcion.Decrypt(data.Where(w => w.Key == "Servidor").FirstOrDefault()!.Value!),
                InitialCatalog = encripcion.Decrypt(data.Where(w => w.Key == "BaseDatos").FirstOrDefault()!.Value!),
                UserID = encripcion.Decrypt(data.Where(w => w.Key == "User").FirstOrDefault()!.Value!),
                Password = encripcion.Decrypt(data.Where(w => w.Key == "Pass").FirstOrDefault()!.Value!),
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}
