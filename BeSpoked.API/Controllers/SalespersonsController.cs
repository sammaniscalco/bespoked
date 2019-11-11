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

            //check if another product name and manufacturer already exists
            var items = _repository.Filter(x => x.Id != salesperson.Id && x.FirstName == salesperson.FirstName && x.LastName == salesperson.LastName && x.Address == salesperson.Address);

            //doesnt exist so add
            if (items == null || (items != null && items.Count() == 0))
            {
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

            //already exists
            return BadRequest("Ssalesperson with Name and Address already exists");
        }

        // POST: api/Salespersons
        [HttpPost]
        public async Task<ActionResult<Salesperson>> PostSalesperson(Salesperson salesperson)
        {
            //check if another product name and manufacturer already exists
            var items = _repository.Filter(x => x.Id != salesperson.Id && x.FirstName == salesperson.FirstName && x.LastName == salesperson.LastName && x.Address == salesperson.Address);

            //doesnt exist so add
            if (items == null || (items != null && items.Count() == 0))
            {
                _repository.Add(salesperson);
                await _repository.SaveChangesAsync();

                return CreatedAtAction("GetSalesperson", new { id = salesperson.Id }, salesperson);
            }

            //already exists
            return BadRequest("Salesperson with Name and Address already exists");
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
