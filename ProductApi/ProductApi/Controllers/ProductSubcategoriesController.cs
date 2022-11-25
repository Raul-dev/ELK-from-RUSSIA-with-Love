using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Data.Models;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSubcategoriesController : ControllerBase
    {
        private readonly ProductApiContext _context;

        public ProductSubcategoriesController(ProductApiContext context)
        {
            _context = context;
        }

        // GET: api/ProductSubcategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSubcategory>>> GetProductSubcategory()
        {
          if (_context.ProductSubcategory == null)
          {
              return NotFound();
          }
            return await _context.ProductSubcategory.ToListAsync();
        }

        // GET: api/ProductSubcategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSubcategory>> GetProductSubcategory(int id)
        {
          if (_context.ProductSubcategory == null)
          {
              return NotFound();
          }
            var productSubcategory = await _context.ProductSubcategory.FindAsync(id);

            if (productSubcategory == null)
            {
                return NotFound();
            }

            return productSubcategory;
        }

        // PUT: api/ProductSubcategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSubcategory(int id, ProductSubcategory productSubcategory)
        {
            if (id != productSubcategory.ProductSubcategoryID)
            {
                return BadRequest();
            }

            _context.Entry(productSubcategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSubcategoryExists(id))
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

        // POST: api/ProductSubcategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductSubcategory>> PostProductSubcategory(ProductSubcategory productSubcategory)
        {
          if (_context.ProductSubcategory == null)
          {
              return Problem("Entity set 'ProductApiContext.ProductSubcategory'  is null.");
          }
            _context.ProductSubcategory.Add(productSubcategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSubcategory", new { id = productSubcategory.ProductSubcategoryID }, productSubcategory);
        }

        // DELETE: api/ProductSubcategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductSubcategory(int id)
        {
            if (_context.ProductSubcategory == null)
            {
                return NotFound();
            }
            var productSubcategory = await _context.ProductSubcategory.FindAsync(id);
            if (productSubcategory == null)
            {
                return NotFound();
            }

            _context.ProductSubcategory.Remove(productSubcategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductSubcategoryExists(int id)
        {
            return (_context.ProductSubcategory?.Any(e => e.ProductSubcategoryID == id)).GetValueOrDefault();
        }
    }
}
