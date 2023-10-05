namespace CursosBiblicos.DTOS
{
    public class RecursosDTO
    {
        public int Id { get; set; }
        public string NombreDelRecurso { get; set; } = null!;
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string? Enlace { get; set; }
    }
}
