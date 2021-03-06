﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeSpoked.Repo;
using BeSpoked.Repo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly BaseRepository<Product> _repository;

        public ProductsController(BaseRepository<Product> repository)
        {
            _repository = repository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _repository.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var product = await _repository.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(long id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            //check if another product name and manufacturer already exists
            var items = _repository.Filter(x => x.Id != product.Id && x.Manufacturer == product.Manufacturer && x.Name == product.Name);

            //doesnt exist so add
            if (items == null || (items != null && items.Count() == 0))
            {
                _repository.Update(product);

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
            return BadRequest("Product with Name and Manufacturer already exists");
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            //check if product name and manufacturer already exists
            var items = _repository.Filter(x => x.Manufacturer == product.Manufacturer && x.Name == product.Name);

            //doesnt exist so add
            if (items == null || (items != null && items.Count() == 0))
            {
                _repository.Add(product);
                await _repository.SaveChangesAsync();

                return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            }

            //already exists
            return BadRequest("Product with Name and Manufacturer already exists");
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(long id)
        {
            var product = await _repository.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _repository.Remove(product);
            await _repository.SaveChangesAsync();

            return product;
        }

    }
}
