namespace CursosBiblicos.DTOS
{
    public class AutenticacionDTO
    {
        public int Id { get; set; }
        public string NombreDeUsuario { get; set; }
        public string Contrasena { get; set; }
        public string? Permisos { get; set; }
    }
}
