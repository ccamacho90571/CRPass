using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = CRPass.DO.Objects;

namespace CRPass.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Representa el casting del objeto a el similar 
            // Desde DO hacia DataModels 
            // Domain to Resource

            CreateMap<data.Empresa, DataModels.Empresa>().ReverseMap();

            CreateMap<data.Tickets, DataModels.Tickets>().ReverseMap();

            CreateMap<data.Boleteria, DataModels.Boleteria>().ReverseMap();


        }
    }
}
