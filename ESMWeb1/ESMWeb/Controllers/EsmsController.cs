using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ESMWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace ESMWeb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EsmsController : ControllerBase
    {
        private readonly ESMDBContext _context;

        public EsmsController(ESMDBContext context)
        {
            _context = context;
        }

        // GET: api/Esms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Esm>>> GetEsm()
        {
            return await _context.Esm.ToListAsync();
        }

        // GET: api/Esms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Esm>> GetEsm(long id)
        {
            var esm = await _context.Esm.Include(obj => obj.HomeDepotNavigation).FirstOrDefaultAsync(obj => obj.EsmId == id);

            if (esm == null)
            {
                return NotFound();
            }

            return esm;
        }

        // PUT: api/Esms/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEsm(long id, Esm esm)
        {
            if (id != esm.EsmId)
            {
                return BadRequest();
            }

            _context.Entry(esm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EsmExists(id))
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

        // POST: api/Esms
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Esm>> PostEsm(Esm esm)
        {
            _context.Esm.Add(esm);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EsmExists(esm.EsmId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEsm", new { id = esm.EsmId }, esm);
        }

        // DELETE: api/Esms/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Esm>> DeleteEsm(long id)
        {
            var esm = await _context.Esm.FindAsync(id);
            if (esm == null)
            {
                return NotFound();
            }

            _context.Esm.Remove(esm);
            await _context.SaveChangesAsync();

            return esm;
        }

        private bool EsmExists(long id)
        {
            return _context.Esm.Any(e => e.EsmId == id);
        }
    }
}
