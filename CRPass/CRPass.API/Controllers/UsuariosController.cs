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
    public class UsuariosController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public UsuariosController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Usuarios>>> GetUsuarios()
        {
            var aux = await new CRPass.BS.Usuarios(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Usuarios>, IEnumerable<datamodels.Usuarios>>(aux).ToList();
            return mapaux;
        }


        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Usuarios>> GetUsuarios(string id)
        {

            var usuarios = await new CRPass.BS.Usuarios(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Usuarios, datamodels.Usuarios>(usuarios);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}/{contrasena}")]
        public async Task<ActionResult<datamodels.Usuarios>> ValidarCredenciales(string usuario, string contrasena)
        {

            var usuarios = await new CRPass.BS.Usuarios(_context).ValidarCredenciales(usuario, contrasena);
            var mapaux = _mapper.Map<data.Usuarios, datamodels.Usuarios>(usuarios);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(string id, datamodels.Usuarios usuarios)
        {
            if (id != usuarios.Usuario)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Usuarios, data.Usuarios>(usuarios);

                new CRPass.BS.Usuarios(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Usuarios>> PostUsuarios(datamodels.Usuarios usuarios)
        {
            var mapaux = _mapper.Map<datamodels.Usuarios, data.Usuarios>(usuarios);

            new CRPass.BS.Usuarios(_context).Insert(mapaux);

            return CreatedAtAction("GetUsuarios", new { id = usuarios.Usuario }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Usuarios>> DeleteUsuarios(string id)
        {
            var usuario = new CRPass.BS.Usuarios(_context).GetOneById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            new CRPass.BS.Usuarios(_context).Delete(usuario);
            var mapaux = _mapper.Map<data.Usuarios, datamodels.Usuarios>(usuario);


            return mapaux;
        }

        private bool UsuariosExists(string id)
        {
            return (new CRPass.BS.Usuarios(_context).GetOneById(id) != null);
        }


    }
}