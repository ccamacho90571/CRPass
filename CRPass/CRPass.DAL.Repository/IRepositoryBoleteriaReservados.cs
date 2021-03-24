using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using System.Threading.Tasks;

namespace CRPass.DAL.Repository
{
    public interface IRepositoryBoleteriaReservados : IRepository<data.BoleteriaReservados>
    {
        Task<IEnumerable<data.BoleteriaReservados>> GetAllWithAsAsync();

        Task<data.BoleteriaReservados> GetByOneWithAsAsync(int id, int id2, int id3);
    }
}
