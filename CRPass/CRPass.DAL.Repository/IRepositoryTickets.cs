using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using System.Threading.Tasks;

namespace CRPass.DAL.Repository
{
    public interface IRepositoryTickets : IRepository<data.Tickets>
    {
        Task<IEnumerable<data.Tickets>> GetAllWithAsAsync();



        Task<data.Tickets> GetByOneWithAsAsync(int id);

        Task<data.Tickets> GetByOneWithAsAsync(string nreserva);
    }
}
