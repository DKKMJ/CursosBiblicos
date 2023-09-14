using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorRecurso
    {
        public int Id { get; set; }
        public string NombreDelRecurso { get; set; } = null!;
        public string? Tipo { get; set; }
        public string? Descripcion { get; set; }
        public string? Enlace { get; set; }
    }
}
