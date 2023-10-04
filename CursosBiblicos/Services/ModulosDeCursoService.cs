using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;

namespace CursosBiblicos.Services
{
    public class ModulosDeCursoService
    {
        public async Task<Response> CrearModuloCurso(ModuloCursoDTO data)
        {
            ModuloCursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        ControladorModulosDeCurso moduloCurso = new()
                        {
                            Curso = data.Curso,
                            Instructor = data.Instructor,
                            Estudiante = data.Estudiante
                        };

                        context.ControladorModulosDeCursos.Add(moduloCurso);
                        context.SaveChanges();

                        response.Data = moduloCurso;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 500;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<ModulosCursoResponse> ListaModulosCurso()
        {
            ModulosCursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var modulosCurso = context.ControladorModulosDeCursos.ToList();

                        response.Data = modulosCurso;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 500;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<Response> ObtenerModuloCurso(int id)
        {
            ModuloCursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var moduloCurso = context.ControladorModulosDeCursos.Find(id);
                        if (moduloCurso == null)
                        {
                            throw new Exception("Módulo de curso no encontrado.");
                        }

                        response.Data = moduloCurso;
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

        public async Task<Response> ActualizarModuloCurso(int id, ModuloCursoDTO data)
        {
            ModuloCursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var moduloCurso = context.ControladorModulosDeCursos.Find(id);
                        if (moduloCurso == null)
                        {
                            throw new Exception("Módulo de curso no encontrado.");
                        }

                        moduloCurso.Curso = data.Curso;
                        moduloCurso.Instructor = data.Instructor;
                        moduloCurso.Estudiante = data.Estudiante;

                        context.SaveChanges();

                        response.Data = moduloCurso;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 500;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        public async Task<Response> EliminarModuloCurso(int id)
        {
            Response response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var moduloCurso = context.ControladorModulosDeCursos.Find(id);
                        if (moduloCurso == null)
                        {
                            throw new Exception("Módulo de curso no encontrado.");
                        }

                        context.ControladorModulosDeCursos.Remove(moduloCurso);
                        context.SaveChanges();

                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    response.Status = false;
                    response.Code = 500;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }
    }

}
