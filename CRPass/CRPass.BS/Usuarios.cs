using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using System.Threading.Tasks;

namespace CRPass.BS
{
    public class Usuarios : ICRUDU<data.Usuarios>
    {
        private SolutionDbContext context;
        public Usuarios(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Usuarios t)
        {
            new DAL.Usuarios(context).Delete(t);
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return new DAL.Usuarios(context).GetAll();
        }

        public data.Usuarios GetOneById(string id)
        {
            return new DAL.Usuarios(context).GetOneById(id);
        }

        public void Insert(data.Usuarios t)
        {
            new DAL.Usuarios(context).Insert(t);
        }

        public void Update(data.Usuarios t)
        {
            new DAL.Usuarios(context).Update(t);
        }

        public async Task<IEnumerable<data.Usuarios>> GetAllWithAsync()
        {
            return await new DAL.Usuarios(context).GetAllWithAsync();
        }

        public async Task<data.Usuarios> GetOneByIdWithAsync(string usuario)
        {
            return await new DAL.Usuarios(context).GetOneByIdWithAsync(usuario);
        }

        public async Task<data.Usuarios> ValidarCredenciales(string usuario, string contrasena)
        {
            return await new DAL.Usuarios(context).ValidarCredenciales(usuario, contrasena);
        }





    }
}
