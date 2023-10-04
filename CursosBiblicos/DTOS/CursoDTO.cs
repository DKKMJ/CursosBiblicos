namespace CursosBiblicos.DTOS
{
    public class CursoDTO
    {
        public int Id { get; set; }
        public string NombreDelCurso { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateOnly? FechaDeCreacion { get; set; }
        public int? Puntaje { get; set; }
    }
}
