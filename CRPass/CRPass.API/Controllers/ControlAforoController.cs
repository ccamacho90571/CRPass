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
    public class ControlAforoController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public ControlAforoController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BoleteriaReservados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.ControlAforo>>> GetControlAforo()
        {
            var aux = new CRPass.BS.ControlAforo(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.ControlAforo>, IEnumerable<datamodels.ControlAforo>>(aux).ToList();
            return mapaux;
        }

        // GET: api/BoleteriaReservados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.ControlAforo>> GetControlAforo(int CodControl, int CodEmpresa, int NumeroDia, int NumeroAforo)
        {
            var ControlAforo = new CRPass.BS.ControlAforo(_context).GetOneByIds(CodControl,  CodEmpresa, NumeroDia, NumeroAforo);

            if (ControlAforo == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.ControlAforo, datamodels.ControlAforo>(ControlAforo);
            return mapaux;
        }

        // PUT: api/BoleteriaReservados/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControlAforo(int id, datamodels.ControlAforo ControlAforo)
        {
            if (id != ControlAforo.CodControl)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.ControlAforo, data.ControlAforo>(ControlAforo);
                new CRPass.BS.ControlAforo(_context).Update(mapaux);
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
        public async Task<ActionResult<datamodels.ControlAforo>> PostControlAforo(datamodels.ControlAforo ControlAforo)
        {
            var mapaux = _mapper.Map<datamodels.ControlAforo, data.ControlAforo>(ControlAforo);
            new CRPass.BS.ControlAforo(_context).Insert(mapaux);

            return CreatedAtAction("GetControlAforo", new { id = ControlAforo.CodControl }, ControlAforo);
        }

        // DELETE: api/BoleteriaReservados/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.ControlAforo>> DeleteControlAforo(int codControl, int CodEmpresa, int NumeroDia, int NumeroAforo)
        {
            var ControlAforo = new CRPass.BS.ControlAforo(_context).GetOneByIds(codControl, CodEmpresa, NumeroDia, NumeroAforo);
            if (ControlAforo == null)
            {
                return NotFound();
            }

            new CRPass.BS.ControlAforo(_context).Delete(ControlAforo);
            var mapaux = _mapper.Map<data.ControlAforo, datamodels.ControlAforo>(ControlAforo);

            return mapaux;
        }

        private bool BoleteriaReservadosExists(int id)
        {
            return _context.BoleteriaReservados.Any(e => e.CodBoletaReservado == id);
        }
    }
}
