using Castor.Entidad.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Datos
{
    public interface IUsuariodatos
    {
        Task<Usuario> ObtenerUsuario(string correo, string contrasena);
        int NuevoUsuario(Usuario usuario);
        int EliminarUsuario(string correo, string contrasena);
    }
}
