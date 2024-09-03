using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Castor.Entidad.DTO
{
    public class BaseDto<T>
    {
        public bool completado { get; set; }
        public string Mensaje { get; set; }
        public T Datos { get; set; }
    }
}
