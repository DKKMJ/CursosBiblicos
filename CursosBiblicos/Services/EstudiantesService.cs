using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CursosBiblicos.Services
{
    public class EstudiantesService
    {
        // Método para crear un estudiante
        public async Task<EstudianteResponse> CrearEstudiante(EstudiantesDTO data)
        {
            // Crear una respuesta de Estudiante
            EstudianteResponse response = new();

            // Usar el contexto de la base de datos
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Verificar si el nombre de usuario ya está registrado
                        var nombreOcupado = (from u in context.ControladorEstudiantes
                                             where u.Nombre == data.Nombre
                                             select u.Nombre).FirstOrDefault();

                        if (nombreOcupado != null)
                        {
                            throw new Exception("Nombre de usuario ya registrado.");
                        }

                        // Crear un nuevo estudiante con los datos proporcionados
                        ControladorEstudiante usuario = new ControladorEstudiante
                        {
                            Nombre = data.Nombre,
                            Apellido = data.Apellido,
                            Apellido2 = data.Apellido2,
                            Direccion = data.Direccion,
                            Mail = data.Mail,
                            Telefono = data.Telefono,
                        };

                        // Agregar el estudiante a la base de datos
                        context.ControladorEstudiantes.Add(usuario);
                        context.SaveChanges();

                        // Configurar la respuesta con el estudiante creado
                        response.Data = usuario;
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
        public async Task<EstudianteResponse> EditarEstudiante(EstudiantesDTO data, int Id)
        {
            EstudianteResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Buscar al estudiante en la base de datos por su ID
                        var Estudiante = (from u in context.ControladorEstudiantes
                                          where u.Id == Id
                                          select u).FirstOrDefault();

                        if (Estudiante != null)
                        {
                            // Verificar si se enviaron datos para actualizar
                            if (!string.IsNullOrEmpty(data.Nombre))
                            {
                                Estudiante.Nombre = data.Nombre;
                            }
                            if (!string.IsNullOrEmpty(data.Apellido))
                            {
                                Estudiante.Apellido = data.Apellido;
                            }
                            if (!string.IsNullOrEmpty(data.Apellido2))
                            {
                                Estudiante.Apellido2 = data.Apellido2;
                            }
                            if (!string.IsNullOrEmpty(data.Direccion))
                            {
                                Estudiante.Direccion = data.Direccion;
                            }
                            if (!string.IsNullOrEmpty(data.Mail))
                            {
                                Estudiante.Mail = data.Mail;
                            }
                            if (!string.IsNullOrEmpty(data.Telefono))
                            {
                                Estudiante.Telefono = data.Telefono;
                            }

                            // Actualizar el estudiante en la base de datos
                            context.ControladorEstudiantes.Update(Estudiante);
                            context.SaveChanges();

                            response.Data = Estudiante;
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
        public async Task<EstudianteResponse> EliminarEstudiante(int Id)
        {
            EstudianteResponse response = new EstudianteResponse();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Buscar al estudiante en la base de datos por su ID
                        var estudiante = context.ControladorEstudiantes.SingleOrDefault(u => u.Id == Id);

                        if (estudiante != null)
                        {
                            // Eliminar el estudiante de la base de datos
                            context.ControladorEstudiantes.Remove(estudiante);
                            context.SaveChanges();

                            response.Data = estudiante;
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
        public async Task<EstudiantesResponse> ListaEstudiante()
        {
            EstudiantesResponse response = new EstudiantesResponse();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Obtener la lista de estudiantes desde la base de datos
                        var usuarios = (from u in context.ControladorEstudiantes
                                        select u).ToList();
                        response.Data = usuarios;
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
