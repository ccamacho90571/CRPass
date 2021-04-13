using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = CRPass.DO.Objects;

namespace CRPass.DAL.Repository
{
    public interface IRepositoryUsuarios: IRepositoryU<data.Usuarios>
    {
        Task<IEnumerable<data.Usuarios>> GetAllWithAsAsync();

        Task<data.Usuarios> GetByOneWithAsAsync(string usuario);


        Task<data.Usuarios> ValidarCredenciales(string usuario,string contrasena);
    }
}
