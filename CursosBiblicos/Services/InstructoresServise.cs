using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;

namespace CursosBiblicos.Services
{
    public class InstructoresServise
    {
            // Método para crear un estudiante
            public async Task<InstructoreResponse> CrearInstructor(InstructoresDTO data)
            {
            // Crear una respuesta de Estudiante
            InstructoreResponse response = new();

                // Usar el contexto de la base de datos
                using (var context = new grupoint_cursosbiblicosContext())
                {
                    try
                    {
                        await Task.Run(() =>
                        {
                            // Verificar si el nombre de usuario ya está registrado
                            var nombreOcupado = (from u in context.ControladorInstructores
                                                 where u.Nombre == data.Nombre
                                                 select u.Nombre).FirstOrDefault();

                            if (nombreOcupado != null)
                            {
                                throw new Exception("Nombre de usuario ya registrado.");
                            }

                            // Crear un nuevo estudiante con los datos proporcionados
                            ControladorInstructore instructore = new ControladorInstructore
                            {
                                Nombre = data.Nombre,
                                Apellido1 = data.Apellido1,
                                Apellido2 = data.Apellido2,
                                Direccion = data.Direccion,
                                Telefono = data.Telefono,
                            };

                            // Agregar el estudiante a la base de datos
                            context.ControladorInstructores.Add(instructore);
                            context.SaveChanges();

                            // Configurar la respuesta con el estudiante creado
                            response.Data = instructore;
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
            public async Task<InstructoreResponse> EditarInstructor(InstructoresDTO data, int Id)
            {
            InstructoreResponse response = new();
                using (var context = new grupoint_cursosbiblicosContext())
                {
                    try
                    {
                        await Task.Run(() =>
                        {
                            // Buscar al estudiante en la base de datos por su ID
                            var instructore = (from u in context.ControladorInstructores
                                              where u.Id == Id
                                              select u).FirstOrDefault();

                            if (instructore != null)
                            {
                                // Verificar si se enviaron datos para actualizar
                                if (!string.IsNullOrEmpty(data.Nombre))
                                {
                                    instructore.Nombre = data.Nombre;
                                }
                                if (!string.IsNullOrEmpty(data.Apellido1))
                                {
                                    instructore.Apellido1 = data.Apellido1;
                                }
                                if (!string.IsNullOrEmpty(data.Apellido2))
                                {
                                    instructore.Apellido2 = data.Apellido2;
                                }
                                if (!string.IsNullOrEmpty(data.Direccion))
                                {
                                    instructore.Direccion = data.Direccion;
                                }
                                if (!string.IsNullOrEmpty(data.Telefono))
                                {
                                    instructore.Telefono = data.Telefono;
                                }

                                // Actualizar el estudiante en la base de datos
                                context.ControladorInstructores.Update(instructore);
                                context.SaveChanges();

                                response.Data = instructore;
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
            public async Task<InstructoreResponse> EliminarInstructor(int Id)
            {
            InstructoreResponse response = new InstructoreResponse();
                using (var context = new grupoint_cursosbiblicosContext())
                {
                    try
                    {
                        await Task.Run(() =>
                        {
                            // Buscar al estudiante en la base de datos por su ID
                            var instructore = context.ControladorInstructores.SingleOrDefault(u => u.Id == Id);

                            if (instructore != null)
                            {
                                // Eliminar el estudiante de la base de datos
                                context.ControladorInstructores.Remove(instructore);
                                context.SaveChanges();

                                response.Data = instructore;
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
            public async Task<InstructoresResponse> ListaInstructores()
            {
            InstructoresResponse response = new InstructoresResponse();
                using (var context = new grupoint_cursosbiblicosContext())
                {
                    try
                    {
                        await Task.Run(() =>
                        {
                            // Obtener la lista de estudiantes desde la base de datos
                            var instructore = (from u in context.ControladorInstructores
                                            select u).ToList();
                            response.Data = instructore;
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
            public async Task<InstructoreResponse> ObtenerInstructor(int Id)
            {
            InstructoreResponse response = new InstructoreResponse();
                using (var context = new grupoint_cursosbiblicosContext())
                {
                    try
                    {
                        await Task.Run(() =>
                        {
                            // Obtener el estudiante desde la base de datos por su ID
                            var instructore = context.ControladorInstructores.Find(Id);

                            if (instructore != null)
                            {
                                response.Data = instructore; // Colocar el estudiante en una lista
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



