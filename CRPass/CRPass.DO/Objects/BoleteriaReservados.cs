using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{
    public partial class BoleteriaReservados
    {
        public int CodBoletaReservado { get; set; }
        public int CodBoleteria { get; set; }
        public int CodTickets { get; set; }
        public int? Cantidad { get; set; }

        public virtual Boleteria CodBoleteriaNavigation { get; set; }
        public virtual Tickets CodTicketsNavigation { get; set; }
    }
}
