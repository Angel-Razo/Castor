using Castor.Entidad.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Datos
{
    public interface IProductoDatos
    {
        int NuevoProducto(Producto producto);
        int EliminarProducto(int idProducto, int idUsuario);
        List<Producto> ObteberProductosActivos();
        List<Producto> ObteberProductosTodos();
    }
}
