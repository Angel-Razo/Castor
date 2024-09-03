using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Entidad.Modelos
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int estatus { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaModificacion { get; set; }
        public int idUsuario { get; set; }

    }
}
