using CursosBiblicos.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace CursosBiblicos.Controllers
{
    public class CursoFlujoController : ControllerBase
    {
        [HttpPost("IniciarCurso")]
        public IActionResult IniciarCurso([FromBody] IniciarCursoDTO iniciarCursoDto)
        {
            try
            {
                if (iniciarCursoDto.CursoId <= 0 || iniciarCursoDto.EstudianteId <= 0)
                {
                    return BadRequest(new { Message = "CursoId y EstudianteId deben ser mayores que 0" });
                }

                return Ok(new { Message = "Curso iniciado exitosamente!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Ocurrió un error al iniciar el curso", Error = ex.Message });
            }
        }   
    }
}
