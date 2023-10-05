using CursosBiblicos.Controllers;
using CursosBiblicos.Models;

namespace CursosBiblicos.Responses
{
    public class Response
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
        public object Data { get; set; }
    }

    public class EstudiantesResponse : Response  //se usa para retornar en la data un objeto que contiene una lista de objetos de tipo Usuario
    {
        public List<ControladorEstudiante> Data { get; set; }
    }

    public class EstudianteResponse : Response  //se usa para retornar en la data un objeto de tipo Usuario
    {
        public ControladorEstudiante Data { get; set; }
    }

    public class CalificacionResponse : Response
    {
        public ControladorCalificacione Data { get; set; }
    }

    public class CalificacionesResponse : Response
    {
        public List<ControladorCalificacione> Data { get; set; }
    }

    public class InscripcionResponse : Response
    {
        public ControladorInscripcione Data { get; set; }
    }

    public class InscripcionesResponse : Response
    {
        public List<ControladorInscripcione> Data { get; set; }
    }

    public class CursosResponse : Response  //se usa para retornar en la data un objeto que contiene una lista de objetos de tipo Curso
    {
        public List<ControladorCurso> Data { get; set; }
    }

    public class CursoResponse : Response  //se usa para retornar en la data un objeto de tipo curso
    {
        public ControladorCurso Data { get; set; }
    }

    public class ModuloCursoResponse : Response
    {
        public ControladorModulosDeCurso Data { get; set; }
    }

    public class ModulosCursoResponse : Response
    {
        public List<ControladorModulosDeCurso> Data { get; set; }
    }
    public class InstructoresResponse : Response  //se usa para retornar en la data un objeto que contiene una lista de objetos de tipo Usuario
    {
        public List<ControladorInstructore> Data { get; set; }
    }

    public class InstructoreResponse : Response  //se usa para retornar en la data un objeto de tipo Usuario
    {
        public ControladorInstructore Data { get; set; }
    }
    public class RecursosResponse : Response  //se usa para retornar en la data un objeto que contiene una lista de objetos de tipo Usuario
    {
        public List<ControladorRecurso> Data { get; set; }
    }

    public class RecursoResponse : Response  //se usa para retornar en la data un objeto de tipo Usuario
    {
        public ControladorRecurso Data { get; set; }
    }
    public class AutenticacionesResponse : Response  //se usa para retornar en la data un objeto que contiene una lista de objetos de tipo Usuario
    {
        public List<ControladorAutenticacion> Data { get; set; }
    }

    public class AutenticacionResponse : Response  //se usa para retornar en la data un objeto de tipo Usuario
    {
        public ControladorAutenticacion Data { get; set; }
    }
}

