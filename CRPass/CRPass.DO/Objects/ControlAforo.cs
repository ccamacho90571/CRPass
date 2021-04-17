using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{



    public class ControlAforo

    {
        public int CodControl { get; set; }
        public int CodEmpresa { get; set; }
        public int NumeroDia { get; set; }
        public int NumeroAforo { get; set; }

        public virtual Empresa CodEmpresaNavigation { get; set; }
    }
}
