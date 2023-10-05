using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
        public class RecursosController : ControllerBase // Debe heredar de ControllerBase
        {
            RecursosServices service = new();

            public RecursosController()
            {
                service = new RecursosServices();
            }

            [HttpPost("crear-Recursos")]
            public async Task<IActionResult> CrearRecurso([FromBody] RecursosDTO data)
            {
                var response = await service.CrearRecurso(data);
                return new JsonResult(response) { StatusCode = response.Code };
            }

            [HttpGet("lista-Recursos")]
            public async Task<IActionResult> ListaRecursos()
            {
                var response = await service.ListaRecursos();
                return new JsonResult(response) { StatusCode = response.Code };
            }

            [HttpGet("obtener-Recursos/{id}")]
            public async Task<IActionResult> ObtenerRecurso(int id)
            {
                var response = await service.ObtenerRecurso(id);
                return new JsonResult(response) { StatusCode = response.Code };
            }

            [HttpPut("actualizar-Recursos/{id}")]
            public async Task<IActionResult> ActualizarRecurso(int Id, [FromBody] RecursosDTO data)
            {
                var response = await service.ActualizarRecurso(data, Id);
                return new JsonResult(response) { StatusCode = response.Code };
            }


            [HttpDelete("eliminar-Recursos/{id}")]
            public async Task<IActionResult> EliminarRecurso(int id)
            {
                var response = await service.EliminarRecurso(id);
                return new JsonResult(response) { StatusCode = response.Code };
            }


        }
    }

