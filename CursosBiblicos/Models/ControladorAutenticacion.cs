using System;
using System.Collections.Generic;

namespace CursosBiblicos.Models
{
    public partial class ControladorAutenticacion
    {
        public int Id { get; set; }
        public string NombreDeUsuario { get; set; } = null!;
        public string Contrasena { get; set; } = null!;
        public string? Permisos { get; set; }
    }
}
