using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Materia.Aplication.Envoltorios
{
    public class Respuesta<T>
    {
        public Respuesta() { }

        public Respuesta(T datos, string mensaje = null, HttpStatusCode codigoEstado = HttpStatusCode.OK)
        {
            CodigoEstado = codigoEstado;
            RespuestaEstado = true;
            Mensaje = mensaje;
            Valores = datos;
        }

        public Respuesta(string mensaje, HttpStatusCode codigoEstado = HttpStatusCode.NotFound)
        {
            CodigoEstado = codigoEstado;
            RespuestaEstado = false;
            Mensaje = mensaje;
        }

        public HttpStatusCode CodigoEstado { get; set; }
        public bool RespuestaEstado { get; set; }
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; }
        public T Valores { get; set; }
    }
}
