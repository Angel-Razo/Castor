using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Entidad.Modelos
{
    public class Venta
    {
        public int idVenta { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public int idUsuario { get; set; }
        public int estatus { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }
    }
}
