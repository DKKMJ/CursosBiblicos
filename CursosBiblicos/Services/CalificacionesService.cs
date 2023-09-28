using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;

namespace CursosBiblicos.Services
{
    public class CalificacionesService
    {
        public async Task<Response> CrearCalificacion(CalificacionDTO data)
        {
            CalificacionResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    // Verifica si el estudiante existe en la base de datos
                    var estudianteExiste = context.ControladorEstudiantes.Any(e => e.Id == data.Estudiante);
                    if (!estudianteExiste)
                    {
                        response.Status = false;
                        response.Code = 400;
                        response.Message = "Error: El estudiante no existe.";
                        return response;
                    }

                    // Verifica si el curso existe en la base de datos
                    //var cursoExiste = context.ControladorCursos.Any(c => c.Id == data.Curso);
                    //if (!cursoExiste)
                    //{
                     //   response.Status = false;
                     //   response.Code = 400;
                      //  response.Message = "Error: El curso no existe.";
                     //   return response;
                   // }

                    await Task.Run(() =>
                    {
                        ControladorCalificacione calificacion = new()
                        {
                            Calificacion = data.Calificacion,
                            Fecha = data.Fecha,
                            Estudiante = data.Estudiante,
                           // Curso = data.Curso
                        };

                        context.ControladorCalificaciones.Add(calificacion);
                        context.SaveChanges();

                        response.Data = calificacion;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<CalificacionesResponse> ListaCalificaciones()
        {
            CalificacionesResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var calificaciones = (from u in context.ControladorCalificaciones
                                        select u).ToList();

                        response.Data = calificaciones;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<CalificacionesResponse> ObtenerCalificaciones()
        {
            CalificacionesResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var calificaciones = context.ControladorCalificaciones.ToList();
                        response.Data = calificaciones;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<Response> ObtenerCalificacion(int id)
        {
            CalificacionesResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var calificacion = context.ControladorCalificaciones.Find(id);
                        if (calificacion == null)
                        {
                            throw new Exception("Calificación no encontrada.");
                        }

                        response.Data = new List<ControladorCalificacione> { calificacion };
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<CalificacionesResponse> ActualizarCalificacion(int id, CalificacionDTO data)
        {
            CalificacionesResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var calificacion = context.ControladorCalificaciones.Find(id);
                        if (calificacion == null)
                        {
                            throw new Exception("Calificación no encontrada.");
                        }

                        calificacion.Calificacion = data.Calificacion;
                        calificacion.Fecha = data.Fecha;
                        calificacion.Estudiante = data.Estudiante;
                        //calificacion.Curso = data.Curso;

                        context.SaveChanges();

                        response.Data = new List<ControladorCalificacione> { calificacion };
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<CalificacionesResponse> EliminarCalificacion(int id)
        {
            CalificacionesResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var calificacion = context.ControladorCalificaciones.Find(id);
                        if (calificacion == null)
                        {
                            throw new Exception("Calificación no encontrada.");
                        }

                        context.ControladorCalificaciones.Remove(calificacion);
                        context.SaveChanges();

                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }
    }

}
