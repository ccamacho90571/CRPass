using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using data = CRPass.DO.Objects;

namespace CRPass.BS
{
    public class Tickets : ICRUD<data.Tickets>

    {
        private SolutionDbContext context;
        public Tickets(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Tickets t)
        {
            new DAL.Tickets(context).Delete(t);
        }

        public IEnumerable<data.Tickets> GetAll()
        {
            return new DAL.Tickets(context).GetAll();
        }

        public data.Tickets GetOneById(int id)
        {
            return new DAL.Tickets(context).GetOneById(id);
        }

        public void Insert(data.Tickets t)
        {
            new DAL.Tickets(context).Insert(t);
        }

        public void Update(data.Tickets t)
        {
            new DAL.Tickets(context).Update(t);
        }

        public async Task<IEnumerable<data.Tickets>> GetAllWithAsync()
        {
            return await new DAL.Tickets(context).GetAllWithAsync();
        }

        public async Task<data.Tickets> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Tickets(context).GetOneByIdWithAsync(id);
        }

        public async Task<data.Tickets> GetOneByIdWithAsync(string nreserva)
        {
            return await new DAL.Tickets(context).GetOneByIdWithAsync(nreserva);
        }
    }
}
