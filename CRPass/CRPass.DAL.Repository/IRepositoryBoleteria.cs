using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using System.Threading.Tasks;

namespace CRPass.DAL.Repository
{
    public interface IRepositoryBoleteria: IRepository<data.Boleteria>
    {
        Task<IEnumerable<data.Boleteria>> GetAllWithAsAsync();

        Task<data.Boleteria> GetByOneWithAsAsync(int id);
    }
}
