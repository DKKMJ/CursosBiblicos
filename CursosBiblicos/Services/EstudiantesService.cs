using CursosBiblicos.DTOS;
using CursosBiblicos.Models;
using CursosBiblicos.Responses;

namespace CursosBiblicos.Services
{
    public class EstudiantesService
    {
        public async Task<EstudianteResponse> CrearEstudiante(EstudiantesDTO data)
        {
            EstudianteResponse response = new();
            using (var context = new grupoint_cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
                        var nombreOcupado = (from u in context.ControladorEstudiantes
                                             where u.Nombre == data.Nombre
                                             select u.Nombre).FirstOrDefault();

                        if (nombreOcupado != null)
                        {
                            throw new Exception("Nombre de usuario ya registrado.");
                        }

                        ControladorEstudiante usuario = new()

                        {
                           Nombre=data.Nombre , 
                           Apellido=data.Apellido,
                           Apellido2=data.Apellido2,
                           Direccion=data.Direccion,
                           Mail=data.Mail,
                           Telefono=data.Telefono,
                        };

                        context.ControladorEstudiantes.Add(usuario);
                        context.SaveChanges();

                        response.Data = usuario;
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
        public async Task<EstudiantesResponse> ListaEstudiante()
        {
            EstudiantesResponse response = new();
            using (var context = new cursosbiblicosContext())
            {
                try
                {
                    await Task.Run(() =>
                    {
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
