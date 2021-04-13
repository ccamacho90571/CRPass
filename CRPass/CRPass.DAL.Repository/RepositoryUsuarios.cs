using CRPass.DAL.EF;
using CRPass.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = CRPass.DO.Objects;
using Microsoft.EntityFrameworkCore;

namespace CRPass.DAL.Repository
{
    public class RepositoryUsuarios : RepositoryU<data.Usuarios>, IRepositoryUsuarios
    {
        public RepositoryUsuarios(SolutionDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Usuarios>> GetAllWithAsAsync()
        {
            return await _db.Usuarios
              .Include(m => m.CodEmpresaNavigation)
              .ToListAsync();
        }

        public async Task<Usuarios> GetByOneWithAsAsync(string usuario)
        {
            return await _db.Usuarios
             .Include(m => m.CodEmpresaNavigation)
             .SingleOrDefaultAsync(m => m.Usuario == usuario);
        }

        public async Task<Usuarios> ValidarCredenciales(string usuario, string contrasena)
        {
            return await _db.Usuarios
              .Include(m => m.CodEmpresaNavigation)
             .SingleOrDefaultAsync(m => m.Usuario == usuario && m.Contrasena == contrasena);
        }


        private SolutionDbContext _db
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
