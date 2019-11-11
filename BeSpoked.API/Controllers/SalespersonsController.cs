using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeSpoked.Repo.Models;
using BeSpoked.Repo;

namespace BeSpoked.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalespersonsController : ControllerBase
    {
        private readonly BaseRepository<Salesperson> _repository;

        public SalespersonsController(BaseRepository<Salesperson> repository)
        {
            _repository = repository;
        }

        // GET: api/Salespersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salesperson>>> GetSalespersons()
        {
            return await _repository.ToListAsync();
        }

        // GET: api/Salespersons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Salesperson>> GetSalesperson(long id)
        {
            var salesperson = await _repository.FindAsync(id);

            if (salesperson == null)
            {
                return NotFound();
            }

            return salesperson;
        }

        // PUT: api/Salespersons/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesperson(long id, Salesperson salesperson)
        {
            if (id != salesperson.Id)
            {
                return BadRequest();
            }

            _repository.Update(salesperson);

            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Exists(id))
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

        // POST: api/Salespersons
        [HttpPost]
        public async Task<ActionResult<Salesperson>> PostSalesperson(Salesperson salesperson)
        {
            _repository.Add(salesperson);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetSalesperson", new { id = salesperson.Id }, salesperson);
        }

        // DELETE: api/Salespersons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Salesperson>> DeleteSalesperson(long id)
        {
            var salesperson = await _repository.FindAsync(id);
            if (salesperson == null)
            {
                return NotFound();
            }

            _repository.Remove(salesperson);
            await _repository.SaveChangesAsync();

            return salesperson;
        }

    }
}
