using System;
using System.Collections.Generic;
using System.Text;

namespace CRPass.DO.Objects
{
    public partial class Empresa
    {
        public int CodEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int ReservasUsuario { get; set; }

        public virtual ICollection<Boleteria> Boleteria { get; set; }
        //public virtual ICollection<ControlAforo> ControlAforo { get; set; }
<<<<<<< HEAD
=======
        public virtual ICollection<Publicidad> Publicidad { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
>>>>>>> 2d9e87d83908226d0dc1168d26d146be085c1880
        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
