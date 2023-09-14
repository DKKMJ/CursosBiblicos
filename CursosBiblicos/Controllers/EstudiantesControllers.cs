using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
    public class EstudiantesControllers : ControllerBase
    {
        EstudiantesService service = new();

        [HttpPost("crear-Estudiante")]
        public async Task<IActionResult> CrearEstudiante([FromBody] EstudiantesDTO data)
        {
            var response = await service.CrearEstudiante(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("lista-Estudiante")]
        public async Task<IActionResult> ListaEstudiante()
        {
            var response = await service.ListaEstudiante();
            return new JsonResult(response) { StatusCode = response.Code };
        }

    }
}
