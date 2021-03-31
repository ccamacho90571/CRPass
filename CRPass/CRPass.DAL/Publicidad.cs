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
    public class Publicidad : ICRUD<data.Publicidad>
    {
        private RepositoryPublicidad _repo = null;
        public Publicidad(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryPublicidad(solutionDbContext);
        }

        public void Delete(data.Publicidad t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Publicidad> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Publicidad GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Publicidad t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Publicidad t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Publicidad>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Publicidad> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }
    }
}
