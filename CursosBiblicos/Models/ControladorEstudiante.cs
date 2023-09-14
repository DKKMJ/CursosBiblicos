using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorEstudiante
    {
        public ControladorEstudiante()
        {
            ControladorCalificaciones = new HashSet<ControladorCalificacione>();
            ControladorInscripciones = new HashSet<ControladorInscripcione>();
            ControladorModulosDeCursos = new HashSet<ControladorModulosDeCurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? Apellido2 { get; set; }
        public string? Direccion { get; set; }
        public string? Mail { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<ControladorCalificacione> ControladorCalificaciones { get; set; }
        public virtual ICollection<ControladorInscripcione> ControladorInscripciones { get; set; }
        public virtual ICollection<ControladorModulosDeCurso> ControladorModulosDeCursos { get; set; }
    }
}
