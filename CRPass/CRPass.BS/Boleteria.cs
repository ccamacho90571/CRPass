using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using System.Threading.Tasks;

namespace CRPass.BS
{
    public class Boleteria : ICRUD<data.Boleteria>
    {
        private SolutionDbContext context;
        public Boleteria(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Boleteria t)
        {
            new DAL.Boleteria(context).Delete(t);
        }

        public IEnumerable<data.Boleteria> GetAll()
        {
            return new DAL.Boleteria(context).GetAll();
        }

        public data.Boleteria GetOneById(int id)
        {
            return new DAL.Boleteria(context).GetOneById(id);
        }

        public void Insert(data.Boleteria t)
        {
            new DAL.Boleteria(context).Insert(t);
        }

        public void Update(data.Boleteria t)
        {
            new DAL.Boleteria(context).Update(t);
        }

        public async Task<IEnumerable<data.Boleteria>> GetAllWithAsync()
        {
            return await new DAL.Boleteria(context).GetAllWithAsync();
        }

        public async Task<data.Boleteria> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Boleteria(context).GetOneByIdWithAsync(id);
        }
    }
}
