using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Entidad.Modelos
{
    public class Usuario
    {
        public int? idUsuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public int idRol { get; set; }
        public string? descripcion { get; set; }
        public int? estatus { get; set; }
    }
}
