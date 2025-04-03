using FluentValidation;
using Materia.Aplication.Interfaces;
using Materia.Aplication.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // Registro de AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Registro automático de todos los validadores en el ensamblado actual
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Configuración de MediatR para todos los ensamblados del proyecto "Notificacion"
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToArray();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));

            // Configuración de servicios
            services.AddTransient<IUsuarioServicio, UsuarioServicio>();
        }
    }
}
