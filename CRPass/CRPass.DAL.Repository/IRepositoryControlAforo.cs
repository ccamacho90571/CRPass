using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using System.Threading.Tasks;

namespace CRPass.DAL.Repository
{
    public interface IRepositoryControlAforo : IRepository<data.ControlAforo>
    {
        Task<IEnumerable<data.ControlAforo>> GetAllWithAsAsync();

        Task<data.ControlAforo> GetByOneWithAsAsync(int id);

     
    }
}
