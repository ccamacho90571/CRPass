using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{
    public partial class Boleteria
    {
        public int CodBoleteria { get; set; }
        public int CodEmpresa { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }

        public virtual Empresa CodEmpresaNavigation { get; set; }
        public virtual ICollection<BoleteriaReservados> BoleteriaReservados { get; set; }
    }
}
