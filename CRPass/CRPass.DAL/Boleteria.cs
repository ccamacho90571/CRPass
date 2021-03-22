using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DAL.Repository;
using CRPass.DO.Interfaces;
using System.Threading.Tasks;

namespace CRPass.DAL
{
    public class Boleteria : ICRUD<data.Boleteria>
    {
        private RepositoryBoleteria _repo = null;
        public Boleteria(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryBoleteria(solutionDbContext);
        }

        public void Delete(data.Boleteria t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Boleteria> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Boleteria GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Boleteria t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Boleteria t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Boleteria>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Boleteria> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }
    }
}
