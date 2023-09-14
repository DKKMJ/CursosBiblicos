namespace CursosBiblicos.Models
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Rut { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido1 { get; set; } = null!;
        public string Apellido2 { get; set; } = null!;
        public int NumeroTelefono { get; set; }

    }
}
