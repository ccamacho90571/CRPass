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
    public class Usuarios : ICRUDU<data.Usuarios>
    {
        private RepositoryUsuarios _repo = null;
        public Usuarios(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryUsuarios(solutionDbContext);
        }

        public void Delete(data.Usuarios t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Usuarios GetOneById(string id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Usuarios t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Usuarios t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Usuarios>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Usuarios> GetOneByIdWithAsync(string usuario)
        {
            return await _repo.GetByOneWithAsAsync(usuario);
        }

        public async Task<data.Usuarios> ValidarCredenciales(string usuario, string contrasena)
        {
            return await _repo.ValidarCredenciales(usuario, contrasena);
        }



    }
}
