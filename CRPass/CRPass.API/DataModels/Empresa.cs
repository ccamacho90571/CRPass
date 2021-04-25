using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRPass.API.DataModels
{
    public class Empresa
    {
      
        public int CodEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int ReservasUsuario { get; set; }

    }
}
