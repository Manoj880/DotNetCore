using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniProject.Data;
using MiniProject.Model;

namespace MiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product_InfoController : ControllerBase
    {
        private readonly MiniProjectContext _context;

        public Product_InfoController(MiniProjectContext context)
        {
            _context = context;
        }

        // GET: api/Product_Info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product_Info>>> GetProduct_Info()
        {
          if (_context.Product_Info == null)
          {
              return NotFound();
          }
            return await _context.Product_Info.ToListAsync();
        }

        // GET: api/Product_Info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product_Info>> GetProduct_Info(int id)
        {
          if (_context.Product_Info == null)
          {
              return NotFound();
          }
            var product_Info = await _context.Product_Info.FindAsync(id);

            if (product_Info == null)
            {
                return NotFound();
            }

            return product_Info;
        }

        // PUT: api/Product_Info/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct_Info(int id, Product_Info product_Info)
        {
            if (id != product_Info.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Product_InfoExists(id))
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

        // POST: api/Product_Info
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product_Info>> PostProduct_Info(Product_Info product_Info)
        {
          if (_context.Product_Info == null)
          {
              return Problem("Entity set 'MiniProjectContext.Product_Info'  is null.");
          }
            _context.Product_Info.Add(product_Info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct_Info", new { id = product_Info.ProductID }, product_Info);
        }

        // DELETE: api/Product_Info/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct_Info(int id)
        {
            if (_context.Product_Info == null)
            {
                return NotFound();
            }
            var product_Info = await _context.Product_Info.FindAsync(id);
            if (product_Info == null)
            {
                return NotFound();
            }

            _context.Product_Info.Remove(product_Info);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Product_InfoExists(int id)
        {
            return (_context.Product_Info?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
