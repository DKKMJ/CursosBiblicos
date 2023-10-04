using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;
using Microsoft.EntityFrameworkCore;

namespace CursosBiblicos.Services
{
    public class CursoService
    {
        public async Task<Response> CrearCurso(CursoDTO data)
        {
            CursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    // Verifica si el curso ya existe en la base de datos
                    var cursoExiste = context.ControladorCursos.Any(e => e.NombreDelCurso == data.NombreDelCurso);
                    if (cursoExiste)
                    {
                        response.Status = false;
                        response.Code = 400;
                        response.Message = "Error: El curso ya existe.";
                        return response;
                    }

                    await Task.Run(() =>
                    {
                        ControladorCurso curso = new()
                        {
                            NombreDelCurso = data.NombreDelCurso,
                            Descripcion = data.Descripcion,
                            FechaDeCreacion = data.FechaDeCreacion,
                            Puntaje = data.Puntaje,
                        };

                        context.ControladorCursos.Add(curso);
                        context.SaveChanges();

                        response.Data = curso;
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

        public async Task<CursosResponse> ListaCursos()
        {
            CursosResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var cursos = (from u in context.ControladorCursos
                                              select u).ToList();

                        response.Data = cursos;
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

        public async Task<Response> ObtenerCurso(int id)
        {
            CursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var curso = context.ControladorCursos.Find(id);
                        if (curso == null)
                        {
                            throw new Exception("Curso no encontrado.");
                        }

                        response.Data = curso;
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

        public async Task<CursoResponse> ActualizarCurso(int id, CursoDTO data)
        {
            CursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var curso = context.ControladorCursos.Find(id);
                        if (curso == null)
                        {
                            throw new Exception("Curso no encontrado.");
                        }

                        curso.NombreDelCurso = data.NombreDelCurso;
                        curso.Descripcion = data.Descripcion;
                        curso.FechaDeCreacion = data.FechaDeCreacion;
                        curso.Puntaje = data.Puntaje;


                        context.SaveChanges();
                        response.Data = new List<ControladorCurso> {curso};
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

        public async Task<CursoResponse> EliminarCurso(int id)
        {
            CursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var curso = context.ControladorCursos.Find(id);
                        if (curso == null)
                        {
                            throw new Exception("Curso no encontrada.");
                        }

                        context.ControladorCursos.Remove(curso);
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

