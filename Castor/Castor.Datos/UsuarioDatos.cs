using Castor.Datos.Configuracion;
using Castor.Datos.Dicionario;
using Castor.Entidad.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;


namespace Castor.Datos
{
    public class UsuarioDatos : IUsuariodatos
    {
        private readonly ConfiguracionConexion _SQlServer;
        public UsuarioDatos(IOptions<ConfiguracionConexion> SQlServer)
        {
            _SQlServer = SQlServer.Value;
        }
        public async Task<Usuario> ObtenerUsuario(string correo, string contrasena)
        {
            Usuario usuario=new Usuario();

            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand command = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Usuario_Obt, sqlServer);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(nameof(Usuario.correo), correo);
                command.Parameters.AddWithValue(nameof(Usuario.contrasena), contrasena);

                SqlDataReader reader = await command.ExecuteReaderAsync();
                if (reader.Read())
                {

                    usuario.idUsuario = Convert.ToInt32(reader[nameof(Usuario.idUsuario)]);
                    usuario.nombre = reader[nameof(Usuario.nombre)].ToString();
                    usuario.contrasena = reader[nameof(Usuario.contrasena)].ToString();
                    usuario.correo = reader[nameof(Usuario.correo)].ToString();
                    usuario.idRol = Convert.ToInt32(reader[nameof(Usuario.idRol)]);
                    usuario.descripcion = reader[nameof(Usuario.descripcion)].ToString();
                    usuario.estatus = Convert.ToInt32(reader[nameof(Usuario.estatus)]);

                }
            }
            return usuario;
        }

        public int NuevoUsuario(Usuario usuario)
        {
            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Usuario_Ins, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(Usuario.correo), usuario.correo);
                cmd.Parameters.AddWithValue(nameof(Usuario.nombre), usuario.nombre);
                cmd.Parameters.AddWithValue(nameof(Usuario.idRol), usuario.idRol);
                cmd.Parameters.AddWithValue(nameof(Usuario.contrasena), usuario.contrasena);

                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            };
        }

        public int EliminarUsuario(string correo, string contrasena)
        {
            using (var sqlServer = new SqlConnection(_SQlServer.SQlServer))
            {
                sqlServer.Open();
                SqlCommand cmd = new SqlCommand(ProcedimientosAlmacenados.Usp_Tb_Usuario_Del, sqlServer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(nameof(Usuario.correo), correo);
                cmd.Parameters.AddWithValue(nameof(Usuario.contrasena), contrasena);

                var dr = cmd.ExecuteNonQuery();
                return Convert.ToInt32(dr);
            }
           ;
        }

    }
}
