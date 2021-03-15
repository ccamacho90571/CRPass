using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using CRPass.DAL.Repository;

namespace CRPass.DAL
{
    public class Empresa : ICRUD<data.Empresa>
    {
        private Repository<data.Empresa> _repo = null;
        public Empresa(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Empresa>(solutionDbContext);
        }

        public void Delete(data.Empresa t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Empresa> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Empresa GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Empresa t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Empresa t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
