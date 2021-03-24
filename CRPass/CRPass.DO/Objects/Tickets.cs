using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{
    public partial class Tickets
    {
        public int CodTicket { get; set; }
        public string Nreserva { get; set; }
        public string Usuario { get; set; }
        public int CodEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public int? Estado { get; set; }
        public virtual ICollection<BoleteriaReservados> BoleteriaReservados { get; set; }

    }
}
