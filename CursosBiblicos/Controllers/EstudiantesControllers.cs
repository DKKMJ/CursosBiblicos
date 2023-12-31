﻿using CursosBiblicos.DTOS;
using CursosBiblicos.Services;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
    public class Estudiantes : ControllerBase
    {
        // Instancia del servicio de estudiantes
        EstudiantesService service = new EstudiantesService();

        // Endpoint para crear un estudiante
        [HttpPost("Crear-Estudiante")]
        public async Task<IActionResult> CrearEstudiante([FromBody] EstudiantesDTO data)
        {
            var response = await service.CrearEstudiante(data);// Llamar al método de servicio para crear un estudiante
            return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
        }

        // Endpoint para editar un estudiante
        [HttpPut("Editar-Estudiante/{id}")]
        public async Task<IActionResult> EditarEstudiante([FromBody] EstudiantesDTO data, int id)
        {
            var response = await service.EditarEstudiante(data, id); // Llamar al método de servicio para editar un estudiante
            return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
        }

        // Endpoint para eliminar un estudiante
        [HttpDelete("Eliminar-Estudiante/{id}")]
        public async Task<IActionResult> EliminarEstudiante(int id)
        {
            var response = await service.EliminarEstudiante(id);// Llamar al método de servicio para eliminar un estudiante
            return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
        }
        [HttpGet("ObtenerEstudiante/{id}")]  // Cambiar "OptenerEstudiante" a "ObtenerEstudiante"
        public async Task<IActionResult> ObtenerEstudiante(int id)
        {
            var response = await service.ObtenerEstudiante(id); // Llamar al método correcto: ObtenerEstudiante
            return new JsonResult(response) { StatusCode = response.Code };
        }


        // Endpoint para obtener la lista de estudiantes
        [HttpGet("Lista-Estudiante")]
        public async Task<IActionResult> ListaEstudiante()
        {
            var response = await service.ListaEstudiante();// Llamar al método de servicio para obtener la lista de estudiantes
            return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
        }
    }
}
