using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
    public class CursoControllers : ControllerBase
    {
        CursoService service = new();

        [HttpPost("crear-Curso")]
        public async Task<IActionResult> CrearCurso([FromBody] CursoDTO data)
        {
            var response = await service.CrearCurso(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("lista-Curso")]
        public async Task<IActionResult> ListaCursos()
        {
            var response = await service.ListaCursos();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("obtener-Curso/{id}")]
        public async Task<IActionResult> ObtenerCurso(int id)
        {
            var response = await service.ObtenerCurso(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("actualizar-Curso/{id}")]
        public async Task<IActionResult> ActualizarCurso(int id, [FromBody] CursoDTO data)
        {
            var response = await service.ActualizarCurso(id, data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-Curso/{id}")]
        public async Task<IActionResult> EliminarCurso(int id)
        {
            var response = await service.EliminarCurso(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }

    }
}


