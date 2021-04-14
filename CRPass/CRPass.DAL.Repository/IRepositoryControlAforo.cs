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

        Task<data.ControlAforo> GetByOneWithAsAsync(int id, int id2, int id3, int id4);
    }
}
