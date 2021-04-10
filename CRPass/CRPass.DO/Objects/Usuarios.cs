using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{
    public class Usuarios
    {

        public int CodUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public virtual Empresa CodEmpresaNavigation { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }

    }
}
