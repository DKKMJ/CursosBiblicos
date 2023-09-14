using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorCalificacione
    {
        public int Id { get; set; }
        public decimal? Calificacion { get; set; }
        public DateOnly? Fecha { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }

        public virtual ControladorCurso? CursoNavigation { get; set; }
        public virtual ControladorEstudiante? EstudianteNavigation { get; set; }
    }
}
