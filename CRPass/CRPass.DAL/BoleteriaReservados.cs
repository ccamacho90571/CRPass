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
    public class BoleteriaReservados : ICRUD<data.BoleteriaReservados>
    {
        private RepositoryBoleteriaReservados _repo = null;
        public BoleteriaReservados(SolutionDbContext solutionDbContext)
        {
            _repo = new RepositoryBoleteriaReservados(solutionDbContext);
        }

        public void Delete(data.BoleteriaReservados t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.BoleteriaReservados> GetAll()
        {
            return _repo.GetAll();
        }

        public data.BoleteriaReservados GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public data.BoleteriaReservados GetOneByIds(int CodBoleteriaReservados, int CodBoleteria, int CodTickets)
        {
            return _repo.GetOneByIds(CodBoleteriaReservados, CodBoleteria, CodTickets);
        }

        public void Insert(data.BoleteriaReservados t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.BoleteriaReservados t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.BoleteriaReservados>> GetAllWithAsync()
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.BoleteriaReservados> GetOneByIdWithAsync(int CodBoleteriaReservados, int CodBoleteria, int CodTickets)
        {
            return await _repo.GetByOneWithAsAsync(CodBoleteriaReservados, CodBoleteria, CodTickets);
        }
    }
}
