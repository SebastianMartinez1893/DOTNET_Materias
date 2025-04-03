using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Text.Json;
using Materia.Aplication.Envoltorios;

namespace Materias.Api.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Respuesta<string>() { RespuestaEstado = false, Mensaje = error?.Message, CodigoEstado = HttpStatusCode.InternalServerError };
                switch (error)
                {
                    case Materia.Aplication.Excepciones.ApiException e:
                        responseModel.CodigoEstado = HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        responseModel.CodigoEstado = HttpStatusCode.NotFound;
                        break;
                    default:
                        responseModel.CodigoEstado = HttpStatusCode.InternalServerError;
                        break;
                }

                await SetContext(context, responseModel, (int)responseModel.CodigoEstado, error);
            }
        }

        private async Task SetContext(HttpContext context, Respuesta<string> result, int statusCode, Exception ex)
        {
            _logger.LogError(
                "Error in ErrorHandlerMiddleware " +
                "at {datetime}, " +
                "with status code {statusCode} " +
                "and exception {exception}"
                , DateTime.Now, statusCode, ex);

            Console.WriteLine(ex?.Message);
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}
