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
    public class TicketsController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public TicketsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Tickets>>> GetTickets()
        {
            var aux = new CRPass.BS.Tickets(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Tickets>, IEnumerable<datamodels.Tickets>>(aux).ToList();
            return mapaux;
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Tickets>> GetTickets(int id)
        {
            var tickets = new CRPass.BS.Tickets(_context).GetOneById(id);

            if (tickets == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Tickets, datamodels.Tickets>(tickets);
            return mapaux;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickets(int id, datamodels.Tickets tickets)
        {
            if (id != tickets.CodTicket)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Tickets, data.Tickets>(tickets);
                new CRPass.BS.Tickets(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!TicketsExists(id))
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

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Tickets>> PostTickets(datamodels.Tickets tickets)
        {
            var mapaux = _mapper.Map<datamodels.Tickets, data.Tickets>(tickets);
            new CRPass.BS.Tickets(_context).Insert(mapaux);

            return CreatedAtAction("GetTickets", new { id = tickets.CodTicket }, tickets);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Tickets>> DeleteTickets(int id)
        {
            var brands = new CRPass.BS.Tickets(_context).GetOneById(id);
            if (brands == null)
            {
                return NotFound();
            }

            new CRPass.BS.Tickets(_context).Delete(brands);
            var mapaux = _mapper.Map<data.Tickets, datamodels.Tickets>(brands);

            return mapaux;
        }

        private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.CodTicket == id);
        }
    }
}
