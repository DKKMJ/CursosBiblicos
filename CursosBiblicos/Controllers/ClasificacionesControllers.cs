using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
    public class CalificacionesController : ControllerBase
    {
        CalificacionesService service = new();

        [HttpPost("crear-Calificacion")]
        public async Task<IActionResult> CrearCalificacion([FromBody] CalificacionDTO data)
        {
            var response = await service.CrearCalificacion(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("lista-Calificaciones")]
        public async Task<IActionResult> ListaCalificaciones()
        {
            var response = await service.ListaCalificaciones();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("obtener-Calificacion/{id}")]
        public async Task<IActionResult> ObtenerCalificacion(int id)
        {
            var response = await service.ObtenerCalificacion(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("actualizar-Calificacion/{id}")]
        public async Task<IActionResult> ActualizarCalificacion(int id, [FromBody] CalificacionDTO data)
        {
            var response = await service.ActualizarCalificacion(id, data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-Calificacion/{id}")]
        public async Task<IActionResult> EliminarCalificacion(int id)
        {
            var response = await service.EliminarCalificacion(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }

    }
}
