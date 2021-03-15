using System;
using System.Collections.Generic;
using System.Text;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using data = CRPass.DO.Objects;

namespace CRPass.BS
{
    public class Empresa : ICRUD<data.Empresa>
    {
        private SolutionDbContext context;
        public Empresa(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Empresa t)
        {
            new DAL.Empresa(context).Delete(t);
        }

        public IEnumerable<data.Empresa> GetAll()
        {
            return new DAL.Empresa(context).GetAll();
        }

        public data.Empresa GetOneById(int id)
        {
            return new DAL.Empresa(context).GetOneById(id);
        }

        public void Insert(data.Empresa t)
        {
            new DAL.Empresa(context).Insert(t);
        }

        public void Update(data.Empresa t)
        {
            new DAL.Empresa(context).Update(t);
        }
    }
}
