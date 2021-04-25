using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using System.Threading.Tasks;

namespace CRPass.BS
{
    public class ControlAforo : ICRUD<data.ControlAforo>
    {
        private SolutionDbContext context;
        public ControlAforo(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.ControlAforo t)
        {
            new DAL.ControlAforo(context).Delete(t);
        }

        public IEnumerable<data.ControlAforo> GetAll()
        {
            return new DAL.ControlAforo(context).GetAll();
        }

        public data.ControlAforo GetOneById(int id)
        {
            return new DAL.ControlAforo(context).GetOneById(id);
        }

        public data.ControlAforo GetOneByIds(int codControl)
        {
            return new DAL.ControlAforo(context).GetOneByIds(codControl);
        }

        public void Insert(data.ControlAforo t)
        {
            new DAL.ControlAforo(context).Insert(t);
        }

        public void Update(data.ControlAforo t)
        {
            new DAL.ControlAforo(context).Update(t);
        }

        public async Task<IEnumerable<data.ControlAforo>> GetAllWithAsync()
        {
            return await new DAL.ControlAforo(context).GetAllWithAsync();
        }
        public async Task<data.ControlAforo> GetOneByIdWithAsync(int CodControl)
        {
            return await new DAL.ControlAforo(context).GetOneByIdWithAsync(CodControl);
        }

    }
}
