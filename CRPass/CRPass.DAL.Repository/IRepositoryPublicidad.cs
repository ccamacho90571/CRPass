using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using System.Threading.Tasks;

namespace CRPass.DAL.Repository
{
    interface IRepositoryPublicidad
    {
        Task<IEnumerable<data.Publicidad>> GetAllWithAsAsync();

        Task<data.Publicidad> GetByOneWithAsAsync(int id);
    }
}
