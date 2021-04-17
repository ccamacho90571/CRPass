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
    public class PublicidadController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public PublicidadController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Publicidads
        [HttpGet]
        public async Task<ActionResult<IEnumerable< datamodels.Publicidad>>> GetPublicidad()
        {
            var aux = await new CRPass.BS.Publicidad(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Publicidad>, IEnumerable<datamodels.Publicidad>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Publicidads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Publicidad>> GetPublicidad(int id)
        {
            var publicidads = new CRPass.BS.Publicidad(_context).GetOneById(id);

            if (publicidads == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Publicidad, datamodels.Publicidad>(publicidads);
            return mapaux;
        }

        // PUT: api/Publicidads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPublicidad(int id, datamodels.Publicidad publicidad)
        {
            if (id != publicidad.CodPublicidad)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Publicidad, data.Publicidad>(publicidad);
                new CRPass.BS.Publicidad(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!PublicidadExists(id))
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

        // POST: api/Publicidads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Publicidad>> PostPublicidad(datamodels.Publicidad publicidad)
        {
            var mapaux = _mapper.Map<datamodels.Publicidad, data.Publicidad>(publicidad);
            new CRPass.BS.Publicidad(_context).Insert(mapaux);

            return CreatedAtAction("GetPublicidad", new { id = publicidad.CodEmpresa }, publicidad);
        }

        // DELETE: api/Publicidads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Publicidad>> DeletePublicidad(int id)
        {
            var publicidad = new CRPass.BS.Publicidad(_context).GetOneById(id);
            if (publicidad == null)
            {
                return NotFound();
            }

            new CRPass.BS.Publicidad(_context).Delete(publicidad);
            var mapaux = _mapper.Map<data.Publicidad, datamodels.Publicidad>(publicidad);

            return mapaux;
        }

        private bool PublicidadExists(int id)
        {
            return _context.Publicidad.Any(e => e.CodPublicidad == id);
        }
    }
}
