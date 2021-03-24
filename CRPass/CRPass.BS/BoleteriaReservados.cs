using System;
using System.Collections.Generic;
using System.Text;
using data = CRPass.DO.Objects;
using CRPass.DAL.EF;
using CRPass.DO.Interfaces;
using System.Threading.Tasks;

namespace CRPass.BS
{
    public class BoleteriaReservados : ICRUD<data.BoleteriaReservados>
    {
        private SolutionDbContext context;
        public BoleteriaReservados(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.BoleteriaReservados t)
        {
            new DAL.BoleteriaReservados(context).Delete(t);
        }

        public IEnumerable<data.BoleteriaReservados> GetAll()
        {
            return new DAL.BoleteriaReservados(context).GetAll();
        }

        public data.BoleteriaReservados GetOneById(int id)
        {
            return new DAL.BoleteriaReservados(context).GetOneById(id);
        }

        public data.BoleteriaReservados GetOneByIds(int CodBoleteriaReservado, int CodBoleteria, int CodTickets)
        {
            return new DAL.BoleteriaReservados(context).GetOneByIds(CodBoleteriaReservado, CodBoleteria, CodTickets);
        }

        public void Insert(data.BoleteriaReservados t)
        {
            new DAL.BoleteriaReservados(context).Insert(t);
        }

        public void Update(data.BoleteriaReservados t)
        {
            new DAL.BoleteriaReservados(context).Update(t);
        }

        public async Task<IEnumerable<data.BoleteriaReservados>> GetAllWithAsync()
        {
            return await new DAL.BoleteriaReservados(context).GetAllWithAsync();
        }

        public async Task<data.BoleteriaReservados> GetOneByIdWithAsync(int CodBoleteriaReservados, int CodBoleteria, int CodTickets)
        {
            return await new DAL.BoleteriaReservados(context).GetOneByIdWithAsync(CodBoleteriaReservados, CodBoleteria, CodTickets);
        }
    }
}
