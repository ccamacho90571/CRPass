using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRPass.API.DataModels
{
    public class BoleteriaReservados
    {
        public int CodBoletaReservado { get; set; }
        public int CodBoleteria { get; set; }
        public int CodTickets { get; set; }
        public int? Cantidad { get; set; }
    }
}
