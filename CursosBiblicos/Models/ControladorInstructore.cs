using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorInstructore
    {
        public ControladorInstructore()
        {
            ControladorModulosDeCursos = new HashSet<ControladorModulosDeCurso>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellido1 { get; set; }
        public string? Apellido2 { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }

        public virtual ICollection<ControladorModulosDeCurso> ControladorModulosDeCursos { get; set; }

       
    }
}
