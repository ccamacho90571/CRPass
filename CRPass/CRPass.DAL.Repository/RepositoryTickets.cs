using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using System.Threading.Tasks;
using CRPass.DAL.EF;
using CRPass.DO.Objects;
using Microsoft.EntityFrameworkCore;

namespace CRPass.DAL.Repository
{
    public class RepositoryTickets : Repository<data.Tickets>, IRepositoryTickets
    {
        public RepositoryTickets(SolutionDbContext context)
              : base(context)
        {

        }

        public async Task<IEnumerable<Tickets>> GetAllWithAsAsync()
        {
            return await _db.Tickets
                .Include(m => m.CodEmpresaNavigation)
                //.Include(m => m.Usuario)
                .ToListAsync();
        }
        public async Task<Tickets> GetByOneWithAsAsync(int id)
        {
            return await _db.Tickets
             .Include(m => m.CodEmpresaNavigation)
             //.Include(m => m.Usuario)
             .SingleOrDefaultAsync(m => m.CodTicket == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }



    }
}
