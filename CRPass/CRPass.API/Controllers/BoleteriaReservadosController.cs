using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRPass.DAL.EF;
using AutoMapper;
using data = CRPass.DO.Objects;
using datamodels = CRPass.API.DataModels;

namespace CRPass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoleteriaReservadosController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public BoleteriaReservadosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BoleteriaReservados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.BoleteriaReservados>>> GetBoleteriaReservados()
        {
            var aux = new CRPass.BS.BoleteriaReservados(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.BoleteriaReservados>, IEnumerable<datamodels.BoleteriaReservados>>(aux).ToList();
            return mapaux;
        }

        // GET: api/BoleteriaReservados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.BoleteriaReservados>> GetBoleteriaReservados(int CodBoleteriaReservado, int CodBoleteria, int CodTickets)
        {
            var boleteriaReservados = new CRPass.BS.BoleteriaReservados(_context).GetOneByIds(CodBoleteriaReservado, CodBoleteria, CodTickets);

            if (boleteriaReservados == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.BoleteriaReservados, datamodels.BoleteriaReservados>(boleteriaReservados);
            return mapaux;
        }

        // PUT: api/BoleteriaReservados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleteriaReservados(int id, datamodels.BoleteriaReservados boleteriaReservados)
        {
            if (id != boleteriaReservados.CodBoletaReservado)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.BoleteriaReservados, data.BoleteriaReservados>(boleteriaReservados);
                new CRPass.BS.BoleteriaReservados(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!BoleteriaReservadosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BoleteriaReservados
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.BoleteriaReservados>> PostBoleteriaReservados(datamodels.BoleteriaReservados boleteriaReservados)
        {
            var mapaux = _mapper.Map<datamodels.BoleteriaReservados, data.BoleteriaReservados>(boleteriaReservados);
            new CRPass.BS.BoleteriaReservados(_context).Insert(mapaux);

            return CreatedAtAction("GetBoleteriaReservados", new { id = boleteriaReservados.CodBoletaReservado }, boleteriaReservados);
        }

        // DELETE: api/BoleteriaReservados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.BoleteriaReservados>> DeleteBoleteriaReservados(int CodBoleteriaReservado, int CodBoleteria, int CodTickets)
        {
            var boleteriaReservados = new CRPass.BS.BoleteriaReservados(_context).GetOneByIds(CodBoleteriaReservado, CodBoleteria, CodTickets);
            if (boleteriaReservados == null)
            {
                return NotFound();
            }

            new CRPass.BS.BoleteriaReservados(_context).Delete(boleteriaReservados);
            var mapaux = _mapper.Map<data.BoleteriaReservados, datamodels.BoleteriaReservados>(boleteriaReservados);

            return mapaux;
        }

        private bool BoleteriaReservadosExists(int id)
        {
            return _context.BoleteriaReservados.Any(e => e.CodBoletaReservado == id);
        }
    }
}
