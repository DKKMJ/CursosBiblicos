using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CursosBiblicos.Services
{
    public class InscripcionesService
    {
        public async Task<Response> CrearInscripcion(IncripcionesDTO data)
        {
            InscripcionResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    // Verificar si el estudiante existe en la base de datos
                    var estudianteExiste = context.ControladorEstudiantes.Any(e => e.Id == data.Estudiante);
                    if (!estudianteExiste)
                    {
                        response.Status = false;
                        response.Code = 400;
                        response.Message = "Error: El estudiante no existe.";
                        return response;
                    }

                    // Verificar si el curso existe en la base de datos
                    var cursoExiste = context.ControladorCursos.Any(c => c.Id == data.Curso);
                    if (!cursoExiste)
                    {
                        response.Status = false;
                        response.Code = 400;
                        response.Message = "Error: El curso no existe.";
                        return response;
                    }

                    await Task.Run(() =>
                    {
                        ControladorInscripcione inscripcion = new()
                        {
                            Estudiante = data.Estudiante,
                            Curso = data.Curso,
                            FechaDeInscripcion = data.FechaDeInscripcion
                        };

                        context.ControladorInscripciones.Add(inscripcion);
                        context.SaveChanges();

                        response.Data = inscripcion;
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

        public async Task<InscripcionesResponse> ListaInscripciones()
        {
            InscripcionesResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var inscripciones = context.ControladorInscripciones.ToList();
                        response.Data = inscripciones;
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

        public async Task<InscripcionResponse> ObtenerInscripcion(int id)
        {
            InscripcionResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var inscripcion = context.ControladorInscripciones.Find(id);
                        if (inscripcion == null)
                        {
                            throw new Exception("Inscripción no encontrada.");
                        }

                        response.Data = inscripcion;
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

        public async Task<InscripcionResponse> ActualizarInscripcion(int id, IncripcionesDTO data)
        {
            InscripcionResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var inscripcion = context.ControladorInscripciones.Find(id);
                        if (inscripcion == null)
                        {
                            throw new Exception("Inscripción no encontrada.");
                        }

                        inscripcion.Estudiante = data.Estudiante;
                        inscripcion.Curso = data.Curso;
                        inscripcion.FechaDeInscripcion = data.FechaDeInscripcion;

                        context.SaveChanges();

                        response.Data = inscripcion;
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

        public async Task<InscripcionResponse> EliminarInscripcion(int id)
        {
            InscripcionResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var inscripcion = context.ControladorInscripciones.Find(id);
                        if (inscripcion == null)
                        {
                            throw new Exception("Inscripción no encontrada.");
                        }

                        context.ControladorInscripciones.Remove(inscripcion);
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
