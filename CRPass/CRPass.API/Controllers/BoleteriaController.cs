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
    public class BoleteriaController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public BoleteriaController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Boleterias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Boleteria>>> GetBoleteria()
        {
            var aux = await new CRPass.BS.Boleteria(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Boleteria>, IEnumerable<datamodels.Boleteria>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Boleterias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Boleteria>> GetBoleteria(int id)
        {
            var boleterias = new CRPass.BS.Boleteria(_context).GetOneById(id);

            if (boleterias == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Boleteria, datamodels.Boleteria>(boleterias);
            return mapaux;
        }

        // PUT: api/Boleterias/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleteria(int id, datamodels.Boleteria boleteria)
        {
            if (id != boleteria.CodBoleteria)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Boleteria, data.Boleteria>(boleteria);
                new CRPass.BS.Boleteria(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!BoleteriaExists(id))
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

        // POST: api/Boleterias
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Boleteria>> PostBoleteria(datamodels.Boleteria boleteria)
        {
            var mapaux = _mapper.Map<datamodels.Boleteria, data.Boleteria>(boleteria);
            new CRPass.BS.Boleteria(_context).Insert(mapaux);

            return CreatedAtAction("GetBoleteria", new { id = boleteria.CodEmpresa }, boleteria);
        }

        // DELETE: api/Boleterias/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Boleteria>> DeleteBoleteria(int id)
        {
            var boleteria = new CRPass.BS.Boleteria(_context).GetOneById(id);
            if (boleteria == null)
            {
                return NotFound();
            }

            new CRPass.BS.Boleteria(_context).Delete(boleteria);
            var mapaux = _mapper.Map<data.Boleteria, datamodels.Boleteria>(boleteria);

            return mapaux;
        }

        private bool BoleteriaExists(int id)
        {
            return _context.Boleteria.Any(e => e.CodBoleteria == id);
        }
    }
}
