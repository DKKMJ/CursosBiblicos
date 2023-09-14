using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorModulosDeCurso
    {
        public int Id { get; set; }
        public int? Curso { get; set; }
        public int? Instructor { get; set; }
        public int? Estudiante { get; set; }

        public virtual ControladorCurso? CursoNavigation { get; set; }
        public virtual ControladorEstudiante? EstudianteNavigation { get; set; }
        public virtual ControladorInstructore? InstructorNavigation { get; set; }
    }
}
