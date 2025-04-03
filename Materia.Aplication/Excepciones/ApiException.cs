using System.Globalization;

namespace Materia.Aplication.Excepciones
{
    public class ApiException : Exception
    {
        public ApiException() : base() { }

        public ApiException(string mensaje) : base(mensaje) { }

        public ApiException(string mensaje, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, mensaje, args))
        {
        }
    }
}
