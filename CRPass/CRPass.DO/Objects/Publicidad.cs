using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{
    public partial class Publicidad
    {
        public int CodPublicidad { get; set; }
        public int CodEmpresa { get; set; }
        public string RutaArchivo { get; set; }

        public virtual Empresa CodEmpresaNavigation { get; set; }
    }
}
