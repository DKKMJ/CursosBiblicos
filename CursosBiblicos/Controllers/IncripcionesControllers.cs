using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
            
        public class InscripcionesController : ControllerBase // Debes heredar de ControllerBase
        {
        InscripcionesService service = new();

        public InscripcionesController()
            {
                service = new InscripcionesService();
            }

            [HttpPost("crear-Inscripcion")]
            public async Task<IActionResult> CrearPersonas([FromBody] IncripcionesDTO data)
            {
                var response = await service.CrearInscripcion(data);
                return new JsonResult(response) { StatusCode = response.Code };
            }

        [HttpGet("lista-Inscripciones")]
        public async Task<IActionResult> ListaInscripciones()
        {
            var response = await service.ListaInscripciones();
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpGet("obtener-Inscripcion/{id}")]
        public async Task<IActionResult> ObtenerInscripcion(int id)
        {
            var response = await service.ObtenerInscripcion(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpPut("actualizar-Inscripcion/{id}")]
        public async Task<IActionResult> ActualizarInscripcion(int id, [FromBody] IncripcionesDTO data)
        {
            var response = await service.ActualizarInscripcion(id, data);
            return new JsonResult(response) { StatusCode = response.Code };
        }

        [HttpDelete("eliminar-Inscripcion/{id}")]
        public async Task<IActionResult> EliminarInscripcion(int id)
        {
            var response = await service.EliminarInscripcion(id);
            return new JsonResult(response) { StatusCode = response.Code };
        }


    }
    
}
