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
    public class RepositoryControlAforo : Repository<data.ControlAforo>, IRepositoryControlAforo
    {
        public RepositoryControlAforo(SolutionDbContext context)
           : base(context)
        {

        }

        public async Task<IEnumerable<ControlAforo>> GetAllWithAsAsync()
        {
            return await _db.ControlAforo
                .Include(m => m.CodEmpresaNavigation)
                .ToListAsync();
        }

    



    
        public async Task<ControlAforo> GetByOneWithAsAsync(int CodControl)
        {
            return await _db.ControlAforo
             .Include(m => m.CodEmpresaNavigation)
             .SingleOrDefaultAsync(m => m.CodControl == CodControl);
        }
        public ControlAforo GetOneByIds(int id)
        {
            return dbContext.Set<ControlAforo>().Find(id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
