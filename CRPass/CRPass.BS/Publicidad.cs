using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using System.Threading.Tasks;

namespace CRPass.BS
{
    public class Publicidad : ICRUD<data.Publicidad>
    {
        private SolutionDbContext context;
        public Publicidad(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Publicidad t)
        {
            new DAL.Publicidad(context).Delete(t);
        }

        public IEnumerable<data.Publicidad> GetAll()
        {
            return new DAL.Publicidad(context).GetAll();
        }

        public data.Publicidad GetOneById(int id)
        {
            return new DAL.Publicidad(context).GetOneById(id);
        }

        public void Insert(data.Publicidad t)
        {
            new DAL.Publicidad(context).Insert(t);
        }

        public void Update(data.Publicidad t)
        {
            new DAL.Publicidad(context).Update(t);
        }

        public async Task<IEnumerable<data.Publicidad>> GetAllWithAsync()
        {
            return await new DAL.Publicidad(context).GetAllWithAsync();
        }

        public async Task<data.Publicidad> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Publicidad(context).GetOneByIdWithAsync(id);
        }
    }
}
