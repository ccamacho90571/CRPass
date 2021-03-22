using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRPass.API.DataModels
{
    public class Boleteria
    {
        public int CodBoleteria { get; set; }
        public int CodEmpresa { get; set; }
        public string Descripcion { get; set; }
        public int Costo { get; set; }
    }
}
