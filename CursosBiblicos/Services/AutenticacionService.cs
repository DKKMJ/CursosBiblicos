using CursosBiblicos.Controllers;
using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;

namespace CursosBiblicos.Services
{
    public class AutenticacionService
    {
        public async Task<AutenticacionResponse> IniciarSesion(AutenticacionDTO data)
        {
            // Crear una respuesta de Estudiante
            AutenticacionResponse response = new();

            // Usar el contexto de la base de datos
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Verificar si el nombre de usuario ya está registrado
                        var nombreOcupado = (from u in context.ControladorAutenticacions
                                             where u.NombreDeUsuario == data.NombreDeUsuario
                                             select u.NombreDeUsuario).FirstOrDefault();

                        if (nombreOcupado != null)
                        {
                            throw new Exception("Nombre de usuario ya registrado.");
                        }

                        // Crear un nuevo estudiante con los datos proporcionados
                        ControladorAutenticacion usuario = new ControladorAutenticacion
                        {
                            NombreDeUsuario = data.NombreDeUsuario,
                            Contrasena = data.Contrasena,
                            Permisos = data.Permisos,
                           
                        };

                        // Agregar el estudiante a la base de datos
                        context.ControladorAutenticacions.Add(usuario);
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
        public async Task<AutenticacionesResponse> ListaUsuarios()
        {
            AutenticacionesResponse response = new AutenticacionesResponse();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        // Obtener la lista de estudiantes desde la base de datos
                        var usuarios = (from u in context.ControladorAutenticacions
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
