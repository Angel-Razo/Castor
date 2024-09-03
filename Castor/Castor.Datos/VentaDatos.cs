using Castor.Datos.Configuracion;
using Castor.Datos.Dicionario;
using Castor.Entidad.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Datos
{
    public class VentaDatos:IVentaDatos
    {
        private readonly ConfiguracionConexion _SQlServer;
        public VentaDatos(IOptions<ConfiguracionConexion> SQlServer)
        {
            _SQlServer = SQlServer.Value;
        }

    }
}
