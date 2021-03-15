using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRPass.API.DataModels
{
    public class Tickets
    {
        public int CodTicket { get; set; }
        public string Nreserva { get; set; }
        public string Usuario { get; set; }
        public int CodEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public int? Estado { get; set; }
    }
}
