using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorInscripcione
    {
        public int Id { get; set; }
        public int? Estudiante { get; set; }
        public int? Curso { get; set; }
        public DateOnly? FechaDeInscripcion { get; set; }

        public virtual ControladorCurso? CursoNavigation { get; set; }
        public virtual ControladorEstudiante? EstudianteNavigation { get; set; }
    }
}
