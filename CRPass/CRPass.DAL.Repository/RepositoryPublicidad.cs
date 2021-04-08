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
    public class RepositoryPublicidad : Repository<data.Publicidad>, IRepositoryPublicidad
    {
        public RepositoryPublicidad(SolutionDbContext context)
         : base(context)
        {

        }

        public async Task<IEnumerable<Publicidad>> GetAllWithAsAsync()
        {
            return await _db.Publicidad
                .Include(m => m.CodEmpresaNavigation)
                .ToListAsync();
        }

        public async Task<Publicidad> GetByOneWithAsAsync(int id)
        {
            return await _db.Publicidad
            .Include(m => m.CodEmpresaNavigation)
            .SingleOrDefaultAsync(m => m.CodEmpresa == id);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
