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
    public class ControlAforo : ICRUD<data.ControlAforo>
    {
        private RepositoryControlAforo _repo = null;
        public ControlAforo(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryControlAforo(solutionDbContext);
        }

        public void Delete(data.ControlAforo t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.ControlAforo> GetAll()
        {
            return _repo.GetAll();
        }

        public data.ControlAforo GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.ControlAforo GetOneByIds(int codControl)
        {
            return _repo.GetOneByIds(codControl);
        }

        public void Insert(data.ControlAforo t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.ControlAforo t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.ControlAforo>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.ControlAforo> GetOneByIdWithAsync(int codControl)
        {
            return await _repo.GetByOneWithAsAsync(codControl);
            
        }

     
    }
}
