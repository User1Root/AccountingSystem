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
    public class DepotsController : ControllerBase
    {
        private readonly ESMDBContext _context;

        public DepotsController(ESMDBContext context)
        {
            _context = context;
        }

        // GET: api/Depots
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depot>>> GetDepot()
        {
            
            return _context.Depot.ToList();
        }

        // GET: api/Depots/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Depot>> GetDepot(long id)
        {

            var depot1 = await _context.Depot.FindAsync(id);

            if (depot1 == null)
            {
                return NotFound();
            }

            return depot1;
        }

        // GET: api/Depots/5
        [HttpGet("GetDepotDetalis/{id}")]
        public async Task<ActionResult<Depot>> GetDepotDetalis(long id)
        {
            //Eager Loading
            //var depot1 = _context.Depot
            //    .Include(dep => dep.Driver)
            //    .Include(dep => dep.EsmHomeDepotNavigation)
            //    .Include(dep => dep.EsmLastDepotNavigation)
            //    .Where(dep => dep.DepotId == id)
            //    .FirstOrDefault();

            //Explicit Loading
            var depot1 = await _context.Depot.SingleAsync(dep => dep.DepotId == id);

            _context.Entry(depot1)
                .Collection(dep => dep.Driver)
                .Query()
                .Where(drv => drv.DriverFirstName.Contains("Олег"))
                .Load();

            _context.Entry(depot1)
                .Collection(dep => dep.EsmLastDepotNavigation)
                .Load();

            if (depot1 == null)
            {
                return NotFound();
            }

            return depot1;
        }

        // GET: api/Depots/5
        [HttpGet("PostDepotDetalis/")]
        public async Task<ActionResult<Depot>> PostDepotDetalis()
        {
            var depot = new Depot();
            depot.DepotId = 25;
            depot.DepotName = "Челябинск";
            _context.Depot.Add(depot);
            _context.SaveChanges();

            var depot1 = _context.Depot
                .Include(dep => dep.Driver)
                .Include(dep => dep.EsmHomeDepotNavigation)
                .Include(dep => dep.EsmLastDepotNavigation)
                .Where(dep => dep.DepotId == depot.DepotId)
                .FirstOrDefault();

            if (depot1 == null)
            {
                return NotFound();
            }

            return depot1;
        }
        // PUT: api/Depots/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepot(long id, Depot depot)
        {
            if (id != depot.DepotId)
            {
                return BadRequest();
            }

            _context.Entry(depot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepotExists(id))
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

        // POST: api/Depots
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Depot>> PostDepot(Depot depot)
        {
            _context.Depot.Add(depot);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepotExists(depot.DepotId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepot", new { id = depot.DepotId }, depot);
        }

        // DELETE: api/Depots/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Depot>> DeleteDepot(long id)
        {
            var depot = await _context.Depot.FindAsync(id);
            if (depot == null)
            {
                return NotFound();
            }

            _context.Depot.Remove(depot);
            await _context.SaveChangesAsync();

            return depot;
        }

        private bool DepotExists(long id)
        {
            return _context.Depot.Any(e => e.DepotId == id);
        }
    }
}
