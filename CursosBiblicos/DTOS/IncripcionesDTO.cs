namespace CursosBiblicos.DTOS
{
    public class IncripcionesDTO
    {
        public int Id { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }
        public DateOnly? FechaDeInscripcion { get; set; }
    }
}
