using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using CRPass.DAL.Repository;

namespace CRPass.DAL
{
    public class Tickets : ICRUD<data.Tickets>
    {
        private Repository<data.Tickets> _repo = null;
        public Tickets(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Tickets>(solutionDbContext);
        }

        public void Delete(data.Tickets t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Tickets> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Tickets GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Tickets t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Tickets t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
