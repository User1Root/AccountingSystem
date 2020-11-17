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

        // GET: api/Esms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Esm>> GetEsm(long id)
        {
            var esm = await _context.Esm
                .FirstOrDefaultAsync(obj => obj.EsmId == id);

            if (esm == null)
            {
                return NotFound();
            }

            return esm;
        }

        // GET: api/Esms/5/Information
        [HttpGet("{id}/Information")]
        public async Task<ActionResult<Esm>> GetEsmAndAllInformationAboutHim(long id)
        {
            var esm = await _context.Esm
                .Include(esm => esm.HomeDepotNavigation)
                .Include(esm => esm.LastDepotNavigation)                
                .FirstOrDefaultAsync(obj => obj.EsmId == id);

            if (esm == null)
            {
                return NotFound();
            }

            return esm;
        }

        // PUT: api/Esms/GiveOut/{id}
        [HttpPut("GiveOut/{id}")]
        public async Task<IActionResult> GiveOutEsm(long id, Esm esm)
        {
            /*status:{
             '1': 'home',
             '2': 'on way',
             '3': 'in depot, but not home
            }
            esm_format:{
            esmId:'',
            LastDriver:''//машинист, которому выдают esm.
            }*/

            if (id != esm.EsmId || esm.LastDriver == null)
            {
                return BadRequest();
            }

            var driver = await _context.Driver.FindAsync(esm.LastDriver);
            if(driver == null || driver.Esm.Count != 0)
            {
                return BadRequest();
            }

            var esmCurrent = await _context.Esm.FindAsync(esm.EsmId);
            if(esmCurrent == null)
            {
                return BadRequest();
            }

            esmCurrent.LastDriver = esm.LastDriver;
            esmCurrent.Status = 2; 
            _context.Entry(esmCurrent).State = EntityState.Modified;

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
                    //TODO:что тут?
                    throw;
                }
            }

            return Ok();
        }

        // PUT: api/Esms/Take/{id}
        [HttpPut("Take/{id}")]
        public async Task<IActionResult> TakeEsm(long id, Esm esm)
        {
            /*status:{
             '1': 'home',
             '2': 'on way',
             '3': 'in depot, but not home
            }
            esm_format:{
            esmId:'',
            LastDepot:''//депо,которое принимает esm.
            }             
             */           

            if (id != esm.EsmId || esm.LastDepot == null)
            {
                return BadRequest();
            }

            var esmCurrent = await _context.Esm.FindAsync(esm.EsmId);
            if (esmCurrent == null)
            {
                return BadRequest();
            }

            if(esm.LastDepot != esmCurrent.HomeDepot)
            {
                esmCurrent.Status = 3;
            }
            else
            {
                esmCurrent.Status = 1;
            }

            esmCurrent.LastDepot = esm.LastDepot;
            _context.Entry(esmCurrent).State = EntityState.Modified;

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
                    //TODO:что тут?
                    throw;
                }
            }

            return Ok();
        }

        private bool EsmExists(long id) => _context.Esm.Any(e => e.EsmId == id);

    }
}

/*         // GET: api/Esms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Esm>>> GetEsm()
        {
            return await _context.Esm.ToListAsync();
        }
        // POST: api/Esms
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

        */