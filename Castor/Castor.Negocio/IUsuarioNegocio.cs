using Castor.Entidad.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Negocio
{
    public interface IUsuarioNegocio
    {
        Task<Usuario> obtenerUsuario(string correo, string contrasena);
    }
}
