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
    public class SalesController : ControllerBase
    {
        private readonly SaleRepository _repository;

        public SalesController(SaleRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Sales
        // GET: api/Sales?startDate=2019-11-01
        // GET: api/Sales?startDate=2019-11-01&endDate=2019-11-03
        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetSales(DateTime? startDate = null, DateTime? endDate = null)
        {
            var items = _repository.Filter(x => (!startDate.HasValue && !endDate.HasValue)
            || (!startDate.HasValue && endDate.HasValue && x.SalesDate <= endDate.Value)
            || (startDate.HasValue && !endDate.HasValue && x.SalesDate >= startDate.Value)
            || (startDate.HasValue && endDate.HasValue && x.SalesDate <= endDate.Value && x.SalesDate >= startDate.Value));

            if (items != null && items.Count() > 0)
            {
                return Ok(items);
            }
            else
            {
                return NotFound();
            }

        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sale>> GetSale(long id)
        {
            var sale = await _repository.FindAsync(id);

            if (sale == null)
            {
                return NotFound();
            }

            return sale;
        }




        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale(long id, Sale sale)
        {
            if (id != sale.Id)
            {
                return BadRequest();
            }

            _repository.Update(sale);

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

        // POST: api/Sales
        [HttpPost]
        public async Task<ActionResult<Sale>> PostSale(Sale sale)
        {
            _repository.Add(sale);
            await _repository.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sale>> DeleteSale(long id)
        {
            var sale = await _repository.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }

            _repository.Remove(sale);
            await _repository.SaveChangesAsync();

            return sale;
        }


    }
}
