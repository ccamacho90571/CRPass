﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{
<<<<<<< HEAD
    class ControlAforo
=======
    public class ControlAforo
>>>>>>> 2c6b03a706f2791a78505b289c401151ab9c72d9
    {
        public int CodControl { get; set; }
        public int CodEmpresa { get; set; }
        public int NumeroDia { get; set; }
        public int NumeroAforo { get; set; }

        public virtual Empresa CodEmpresaNavigation { get; set; }
    }
}
