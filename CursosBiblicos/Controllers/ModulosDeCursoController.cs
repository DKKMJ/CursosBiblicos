using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
    public class ModulosDeCursoController : ControllerBase
    {
        ModulosDeCursoService service = new();

        [HttpPost("crear-ModuloCurso")]
        public async Task<IActionResult> CrearModuloCurso([FromBody] ModuloCursoDTO data)
        {
            var response = await service.CrearModuloCurso(data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("lista-ModulosCurso")]
        public async Task<IActionResult> ListaModulosCurso()
        {
            var response = await service.ListaModulosCurso();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("obtener-ModuloCurso/{id}")]
        public async Task<IActionResult> ObtenerModuloCurso(int id)
        {
            var response = await service.ObtenerModuloCurso(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("actualizar-ModuloCurso/{id}")]
        public async Task<IActionResult> ActualizarModuloCurso(int id, [FromBody] ModuloCursoDTO data)
        {
            var response = await service.ActualizarModuloCurso(id, data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-ModuloCurso/{id}")]
        public async Task<IActionResult> EliminarModuloCurso(int id)
        {
            var response = await service.EliminarModuloCurso(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }
    }
}
