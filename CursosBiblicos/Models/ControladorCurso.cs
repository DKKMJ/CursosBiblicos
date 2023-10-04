using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorCurso
    {
        public ControladorCurso()
        {
            ControladorCalificaciones = new HashSet<ControladorCalificacione>();
            ControladorInscripciones = new HashSet<ControladorInscripcione>();
            ControladorModulosDeCursos = new HashSet<ControladorModulosDeCurso>();
        }

        public int Id { get; set; }
        public string NombreDelCurso { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateOnly? FechaDeCreacion { get; set; }
        public int? Puntaje { get; set; }

        public virtual ICollection<ControladorCalificacione> ControladorCalificaciones { get; set; }
        public virtual ICollection<ControladorInscripcione> ControladorInscripciones { get; set; }
        public virtual ICollection<ControladorModulosDeCurso> ControladorModulosDeCursos { get; set; }

        public static implicit operator ControladorCurso(List<ControladorCurso> v)
        {
            throw new NotImplementedException();
        }
    }
}
