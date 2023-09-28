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
}
