namespace CursosBiblicos.DTOS
{
    public class InstructoresDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
    }
}
