using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;

namespace CursosBiblicos.Services
{
    public class RecursosServices
    {
        public async Task<RecursoResponse> CrearRecurso(RecursosDTO data)
        {
            // Crear una respuesta de Estudiante
            RecursoResponse response = new();

            // Usar el contexto de la base de datos
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Verificar si el nombre de usuario ya está registrado
                        var nombreOcupado = (from u in context.ControladorRecursos
                                             where u.NombreDelRecurso == data.NombreDelRecurso
                                             select u.NombreDelRecurso).FirstOrDefault();

                        if (nombreOcupado != null)
                        {
                            throw new Exception("Nombre de usuario ya registrado.");
                        }

                        // Crear un nuevo estudiante con los datos proporcionados
                        ControladorRecurso Recurso = new ControladorRecurso
                        {
                            NombreDelRecurso = data.NombreDelRecurso,
                            Tipo = data.Tipo,
                            Descripcion = data.Descripcion,
                            Enlace = data.Enlace,

                        };

                        // Agregar el estudiante a la base de datos
                        context.ControladorRecursos.Add(Recurso);
                        context.SaveChanges();

                        // Configurar la respuesta con el estudiante creado
                        response.Data = Recurso;
                        response.Status = true;
                        response.Code = 200;
                        response.Message = "OK";
                    });
                }
                catch (Exception ex)
                {
                    // Configurar la respuesta en caso de error
                    response.Status = false;
                    response.Code = 400;
                    response.Message = "Error: " + ex.Message;
                }
            }
            return response;
        }

        // Método para editar un estudiante
        public async Task<RecursoResponse> ActualizarRecurso(RecursosDTO data, int Id)
        {
            RecursoResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Buscar al estudiante en la base de datos por su ID
                        var Recurso = (from u in context.ControladorRecursos
                                       where u.Id == Id
                                       select u).FirstOrDefault();

                        if (Recurso != null)
                        {
                            // Verificar si se enviaron datos para actualizar
                            if (!string.IsNullOrEmpty(data.NombreDelRecurso))
                            {
                                Recurso.NombreDelRecurso = data.NombreDelRecurso;
                            }
                            if (!string.IsNullOrEmpty(data.Tipo))
                            {
                                Recurso.Tipo = data.Tipo;
                            }
                            if (!string.IsNullOrEmpty(data.Descripcion))
                            {
                                Recurso.Descripcion = data.Descripcion;
                            }
                            if (!string.IsNullOrEmpty(data.Enlace))
                            {
                                Recurso.Enlace = data.Enlace;
                            }


                            // Actualizar el estudiante en la base de datos
                            context.ControladorRecursos.Update(Recurso);
                            context.SaveChanges();

                            response.Data = Recurso;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Estudiante no encontrado";
                        }
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

        // Método para eliminar un estudiante por su ID
        public async Task<RecursoResponse> EliminarRecurso(int Id)
        {
            RecursoResponse response = new RecursoResponse();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Buscar al estudiante en la base de datos por su ID
                        var Recurso = context.ControladorRecursos.SingleOrDefault(u => u.Id == Id);

                        if (Recurso != null)
                        {
                            // Eliminar el estudiante de la base de datos
                            context.ControladorRecursos.Remove(Recurso);
                            context.SaveChanges();

                            response.Data = Recurso;
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "Estudiante eliminado exitosamente.";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Estudiante no encontrado.";
                        }
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

        // Método para obtener la lista de estudiantes
        public async Task<RecursosResponse> ListaRecursos()
        {
            RecursosResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var recursos = (from u in context.ControladorRecursos
                                        select u).ToList();

                        response.Data = recursos;
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

        public async Task<RecursoResponse> ObtenerRecurso(int Id)
        {
            RecursoResponse response = new RecursoResponse();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Obtener el estudiante desde la base de datos por su ID
                        var Recurso = context.ControladorRecursos.Find(Id);

                        if (Recurso != null)
                        {
                            response.Data = Recurso; // Colocar el estudiante en una lista
                            response.Status = true;
                            response.Code = 200;
                            response.Message = "OK";
                        }
                        else
                        {
                            response.Status = false;
                            response.Code = 404;
                            response.Message = "Estudiante no encontrado.";
                        }
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

