namespace Materia.Comun.Modelos
{
    public class Usuario
    {
        public long identificacion { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? celular { get; set; }
        public string? password { get; set; }
        public int rolId { get; set; }
        public int idUsuario { get; set; }
    }
}
