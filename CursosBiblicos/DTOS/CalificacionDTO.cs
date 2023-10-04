using System;
using System.ComponentModel.DataAnnotations;

namespace CursosBiblicos.DTOS
{
    public class CalificacionDTO
    {
        public int Id { get; set; }
        public decimal? Calificacion { get; set; }
        public DateOnly? Fecha { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }
    }
}
