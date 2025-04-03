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
            var connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = data.Where(w => w.Key == "Servidor").FirstOrDefault()!.Value!,
                InitialCatalog = data.Where(w => w.Key == "BaseDatos").FirstOrDefault()!.Value!,
                UserID = data.Where(w => w.Key == "User").FirstOrDefault()!.Value!,
                Password = data.Where(w => w.Key == "Pass").FirstOrDefault()!.Value!,
            };

            return connectionStringBuilder.ConnectionString;
        }
    }
}
