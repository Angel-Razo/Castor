using Castor.Datos;
using Castor.Entidad.Modelos;

namespace Castor.Negocio
{
    public class UsuarioNegocio:IUsuarioNegocio
    {
        private readonly UsuarioDatos _usuarioDatos;
        public UsuarioNegocio(UsuarioDatos usuarioDatos )
        {
            _usuarioDatos = usuarioDatos;
        }
        public async Task<Usuario> obtenerUsuario(string correo, string contrasena)
        {

            return await _usuarioDatos.ObtenerUsuario(correo, contrasena);
        }

    }
}

