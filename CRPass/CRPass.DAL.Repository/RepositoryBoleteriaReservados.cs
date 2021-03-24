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
    public class RepositoryBoleteriaReservados : Repository<data.BoleteriaReservados>, IRepositoryBoleteriaReservados
    {
        public RepositoryBoleteriaReservados(SolutionDbContext context)
           : base(context)
        {

        }

        public async Task<IEnumerable<BoleteriaReservados>> GetAllWithAsAsync()
        {
            return await _db.BoleteriaReservados
                .Include(m => m.CodBoleteriaNavigation)
                .Include(m => m.CodTicketsNavigation)
                .ToListAsync();
        }


        public async Task<BoleteriaReservados> GetByOneWithAsAsync(int CodBoletaReservado, int CodBoleteria, int CodTickets)
        {
            return await _db.BoleteriaReservados
             .Include(m => m.CodBoleteriaNavigation)
             .Include(m => m.CodTicketsNavigation)
             .SingleOrDefaultAsync(m => m.CodBoletaReservado == CodBoletaReservado && m.CodBoleteria == CodBoleteria && m.CodTickets == CodTickets);
        }

        public BoleteriaReservados GetOneByIds(int id, int id2, int id3)
        {
            return dbContext.Set<BoleteriaReservados>().Find(id, id2, id3);
        }

        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
