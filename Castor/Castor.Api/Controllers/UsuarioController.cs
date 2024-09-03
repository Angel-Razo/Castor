using Azure;
using Castor.Datos;
using Castor.Entidad.DTO;
using Castor.Entidad.Modelos;
using Castor.Negocio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Castor.Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public  class UsuarioController : ControllerBase
    {
       // private readonly UsuarioNegocio usuarioNegocio;
        private readonly IUsuariodatos usuarioDatos;

        public UsuarioController(IUsuariodatos _usuarioDatos)
        {
            //usuarioNegocio = _usuarioNegocio;
            usuarioDatos = _usuarioDatos;
        }

        [HttpGet]
        public async Task<BaseDto<Usuario>> Get(string correo, string contrasena)
        {
            BaseDto<Usuario> response = new BaseDto<Usuario>();
            try
            {
                response.completado = true;
                response.Mensaje = "";
                response.Datos = await usuarioDatos.ObtenerUsuario(correo,contrasena);
                if(response.Datos.estatus==0)
                {
                    response.Mensaje = "usuario Desactivado";
                    response.completado = false;
                }
            }
            catch (Exception ex)
            {

                response.completado = false;
                response.Mensaje = ex.Message;
                throw ex;
            }

            return response;

        }

        [HttpPost]
        public BaseDto<int> Post(Usuario usuario)
        {
            BaseDto<int> response = new BaseDto<int>();
            try
            {

                response.completado = true;
                response.Mensaje = "Correcto";
                response.Datos = usuarioDatos.NuevoUsuario(usuario);
            }
            catch (Exception ex)
            {

                response.completado = false;
                response.Mensaje = ex.Message;
                throw ex;
            }
            return response;
        }
        [HttpDelete]
        public BaseDto<int> Delete(string correo, string contrasena)
        {
            BaseDto<int> response = new BaseDto<int>();
            try
            {
                response.completado = true;
                response.Mensaje = "";
                response.Datos =  usuarioDatos.EliminarUsuario(correo, contrasena);
                if (response.Datos > 0)
                {
                    response.Mensaje = "usuario Desactivado";

                }
                else
                {
                    response.Mensaje = "Ha ocurrido un error";
                    response.completado = false;
                }
            }
            catch (Exception ex)
            {

                response.completado = false;
                response.Mensaje = ex.Message;
                throw ex;
            }

            return response;

        }
    }
}
