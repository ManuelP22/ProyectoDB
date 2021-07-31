using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoDB.Clases
{
    class ClassEntidades
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public string destino { get; set; }
        public string ndocumento { get; set; }
        public string nticket { get; set; }

    }
}
