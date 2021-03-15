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
using Microsoft.EntityFrameworkCore;

namespace CRPass.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public EmpresaController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Empresa>>> GetEmpresa()
        {
            var aux = new CRPass.BS.Empresa(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Empresa>, IEnumerable<datamodels.Empresa>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Empresa>> GetEmpresa(int id)
        {
            var empresas = new CRPass.BS.Empresa(_context).GetOneById(id);

            if (empresas == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Empresa, datamodels.Empresa>(empresas);
            return mapaux;
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, datamodels.Empresa empresa)
        {
            if (id != empresa.CodEmpresa)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Empresa, data.Empresa>(empresa);
                new CRPass.BS.Empresa(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!EmpresaExists(id))
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

        // POST: api/Empresas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Empresa>> PostEmpresa(datamodels.Empresa empresa)
        {
            var mapaux = _mapper.Map<datamodels.Empresa, data.Empresa>(empresa);
            new CRPass.BS.Empresa(_context).Insert(mapaux);

            return CreatedAtAction("GetEmpresa", new { id = empresa.CodEmpresa }, empresa);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Empresa>> DeleteEmpresa(int id)
        {
            var empresa = new CRPass.BS.Empresa(_context).GetOneById(id);
            if (empresa == null)
            {
                return NotFound();
            }

            new CRPass.BS.Empresa(_context).Delete(empresa);
            var mapaux = _mapper.Map<data.Empresa, datamodels.Empresa>(empresa);

            return mapaux;
        }

        private bool EmpresaExists(int id)
        {
            return _context.Empresa.Any(e => e.CodEmpresa == id);
        }
    }
}
