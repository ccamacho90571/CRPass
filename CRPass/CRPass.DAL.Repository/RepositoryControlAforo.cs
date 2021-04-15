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

        public async Task<ControlAforo> GetByOneWithAsAsync(int id)
        {
            return await _db.ControlAforo
             .Include(m => m.CodEmpresaNavigation)
             .SingleOrDefaultAsync(m => m.CodEmpresa == id);
        }

        public async Task<ControlAforo> GetByOneWithAsAsync(int CodControl, int CodEmpresa, int NumeroDia, int NumeroAforo)
        {
            return await _db.ControlAforo
             .Include(m => m.CodControl)
             .Include(m => m.CodEmpresa)
             .Include(m => m.NumeroDia)
             .Include(m => m.NumeroAforo)
             .SingleOrDefaultAsync(m => m.CodControl == CodControl && m.CodEmpresa == CodEmpresa && m.NumeroDia == NumeroDia && m.NumeroAforo == NumeroAforo);
        }
        public ControlAforo GetOneByIds(int id, int id2, int id3, int id4)
        {
            return dbContext.Set<ControlAforo>().Find(id, id2, id3, id4);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
