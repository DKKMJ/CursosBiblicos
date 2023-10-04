using Microsoft.AspNetCore.Mvc;
using CursosBiblicos.DTOS;

namespace CursosBiblicos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {

        [HttpPost("IniciarSesion")]
        public IActionResult IniciarSesion([FromBody] AutenticacionDTO autenticacionDTO)
        {
            try
            {
                // Simplemente devuelve un mensaje de inicio de sesión exitoso.
                return Ok(new { Message = "Inicio de sesión exitoso" });
            }
            catch (Exception ex)
            {
                // En caso de error, devuelve un mensaje de error interno del servidor.
                return StatusCode(500, new { Message = "Ocurrió un error al iniciar sesión", Error = ex.Message });
            }
        }
    }
}
