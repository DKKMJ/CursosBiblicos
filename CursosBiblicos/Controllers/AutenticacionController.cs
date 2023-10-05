using Microsoft.AspNetCore.Mvc;
using CursosBiblicos.DTOS;
using CursosBiblicos.Services;

namespace CursosBiblicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {

        AutenticacionService service = new AutenticacionService();

        // Endpoint para crear un estudiante
        [HttpPost("IniciarSesion")]
        public async Task<IActionResult> IniciarSesion([FromBody] AutenticacionDTO data)
        {
            var response = await service.IniciarSesion(data);// Llamar al método de servicio para crear un estudiante
            return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
        }
        [HttpGet("Lista-Estudiante")]
        public async Task<IActionResult> ListaUsuarios()
        {
            var response = await service.ListaUsuarios();// Llamar al método de servicio para obtener la lista de estudiantes
            return new JsonResult(response) { StatusCode = response.Code };// Retornar la respuesta en formato JSON con el código de estado correspondiente
        }
    }
}
