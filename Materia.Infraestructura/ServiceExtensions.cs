using Materia.Infraestructura.Datos;
using Materia.Infraestructura.Interface;
using Materia.Seguridad;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Infraestructura
{
    public static class ServiceExtensions
    {
        public static void AddInstrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var ConnectionString = new Conexion(configuration).ObtenerDatosConexion();

            // Configuración de servicios
            services.AddTransient<IUsuarioRepositorio>(sp => new UsuarioRepositorio(ConnectionString));
            services.AddTransient<EncripcionAES>();
        }
    }
}
