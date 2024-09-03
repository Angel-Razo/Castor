using Castor.Datos.Configuracion;
using Castor.Datos.Dicionario;
using Castor.Entidad.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;


namespace Castor.Datos
{
    public class ProductoDatos : IProductoDatos
    {
        private readonly ConfiguracionConexion _SQlServer;
        public ProductoDatos(IOptions<ConfiguracionConexion> SQlServer)
        {
            _SQlServer = SQlServer.Value;
        }
        public int NuevoProducto(Producto producto)
        {
            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Producto_Ins, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(Producto.nombre), producto.nombre);
                cmd.Parameters.AddWithValue(nameof(Producto.precio), producto.precio);
                cmd.Parameters.AddWithValue(nameof(Producto.idUsuario), producto.idUsuario);

                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            };
        }

        public int EliminarProducto(int idProducto, int idUsuario)
        {
            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Producto_Eli, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(Producto.idProducto), idProducto);
                cmd.Parameters.AddWithValue(nameof(Producto.idUsuario), idUsuario);

                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            };
        }

        public int ActualizarProducto(int idProducto, int idUsuario,string nombre)
        {
            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Producto_Act, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(Producto.idProducto), idProducto);
                cmd.Parameters.AddWithValue(nameof(Producto.idUsuario), idUsuario);
                cmd.Parameters.AddWithValue(nameof(Producto.nombre), nombre);

                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            };
        }

        public List<Producto> ObteberProductosActivos()
        {
            List<Producto> productos = new List<Producto>();

            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand command = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Producto_Obt, sqlServer);
                command.CommandType = CommandType.StoredProcedure;

                using (var dr =  command.ExecuteReader())
                {
                    while ( dr.Read())
                    {
                        productos.Add(new Producto()
                        {
                            idProducto = Convert.ToInt32(dr[nameof(Producto.idProducto)])
                            , idUsuario = Convert.ToInt32(dr[nameof(Producto.idUsuario)])
                            , nombre = dr[nameof(Producto.nombre)].ToString()
                            , estatus = Convert.ToInt32(dr[nameof(Producto.estatus)])
                            , precio = Convert.ToDecimal(dr[nameof(Producto.precio)])
                            , fechaAlta = Convert.ToDateTime(dr[nameof(Producto.fechaAlta)])
                            , fechaModificacion = Convert.ToDateTime(dr[nameof(Producto.fechaModificacion)])
                        });
                    }

                }
            }
        

            return productos;
        }
        public List<Producto> ObteberProductosTodos()
        {
            List<Producto> productos = new List<Producto>();

            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand command = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Producto_Obt_Todo, sqlServer);
                command.CommandType = CommandType.StoredProcedure;

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        productos.Add(new Producto()
                        {
                            idProducto = Convert.ToInt32(dr[nameof(Producto.idProducto)])
                            , idUsuario = Convert.ToInt32(dr[nameof(Producto.idUsuario)])
                            , nombre = dr[nameof(Producto.nombre)].ToString()
                            , estatus = Convert.ToInt32(dr[nameof(Producto.estatus)])
                            , precio = Convert.ToDecimal(dr[nameof(Producto.precio)])
                            , fechaAlta = Convert.ToDateTime(dr[nameof(Producto.fechaAlta)])
                            , fechaModificacion = Convert.ToDateTime(dr[nameof(Producto.fechaModificacion)])
                        });
                    }

                }
            }


            return productos;
        }
    }
}
