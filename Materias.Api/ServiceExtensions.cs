using Materia.Aplication;
using Materia.Infraestructura;
using Serilog;
using Serilog.Events;

namespace Materias.Api
{
    public static class ServiceExtensions
    {

        public static void BaseRegister(this IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            services.RegisterLog(configuration, hostBuilder);
            services.AddInstrastructureLayer(configuration);
            services.AddApplicationLayer(configuration);
        }

        public static void RegisterLog(this IServiceCollection services, IConfiguration configuration, IHostBuilder hostBuilder)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Information)
                .WriteTo.File("../Logs/log.txt", restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day)
                .WriteTo.File("../Logs/logError.txt", restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day)
                .CreateLogger();

            services.AddLogging(static loggingBuilder =>
            {
                loggingBuilder.AddSerilog(dispose: true);
            });
        }
    }
}
