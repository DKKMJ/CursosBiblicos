using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
    {
        public class Instructore : ControllerBase
        {
        // Instancia del servicio de estudiantes
            InstructoresServise service = new InstructoresServise();

            // Endpoint para crear un estudiante
            [HttpPost("Crear-Instructor")]
            public async Task<IActionResult> CrearInstructor([FromBody] InstructoresDTO data)
            {
                var response = await service.CrearInstructor(data);// Llamar al método de servicio para crear un estudiante
                return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
            }

            // Endpoint para editar un estudiante
            [HttpPut("Editar-Instructor/{id}")]
            public async Task<IActionResult> EditarInstructor([FromBody] InstructoresDTO data, int id)
            {
                var response = await service.EditarInstructor(data, id); // Llamar al método de servicio para editar un estudiante
                return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
            }

            // Endpoint para eliminar un estudiante
            [HttpDelete("Eliminar-Instructor/{id}")]
            public async Task<IActionResult> EliminarInstructor(int id)
            {
                var response = await service.EliminarInstructor(id);// Llamar al método de servicio para eliminar un estudiante
                return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
            }
            [HttpGet("Obtener-Instructor/{id}")]  // Cambiar "OptenerEstudiante" a "ObtenerEstudiante"
            public async Task<IActionResult> ObtenerInstructor(int id)
            {
                var response = await service.ObtenerInstructor(id); // Llamar al método correcto: ObtenerEstudiante
                return new JsonResult(response) { StatusCode = response.Code };
            }


            // Endpoint para obtener la lista de estudiantes
            [HttpGet("Lista-Instructores")]
            public async Task<IActionResult> ListaInstructores()
            {
                var response = await service.ListaInstructores();// Llamar al método de servicio para obtener la lista de estudiantes
                return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
            }
        }
    }



