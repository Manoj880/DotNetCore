using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Final_Codebase_Evaluation.Data;
using Final_Codebase_Evaluation.Model;

namespace Final_Codebase_Evaluation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Employee_InfoController : ControllerBase
    {
        private readonly Final_Codebase_EvaluationContext _context;

        public Employee_InfoController(Final_Codebase_EvaluationContext context)
        {
            _context = context;
        }

        // GET: api/Employee_Info
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee_Info>>> GetEmployee_Info()
        {
          if (_context.Employee_Info == null)
          {
              return NotFound();
          }
            return await _context.Employee_Info.ToListAsync();
        }

        // GET: api/Employee_Info/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee_Info>> GetEmployee_Info(int id)
        {
          if (_context.Employee_Info == null)
          {
              return NotFound();
          }
            var employee_Info = await _context.Employee_Info.FindAsync(id);

            if (employee_Info == null)
            {
                return NotFound();
            }

            return employee_Info;
        }

        // PUT: api/Employee_Info/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee_Info(int id, Employee_Info employee_Info)
        {
            if (id != employee_Info.EmployeeID)
            {
                return BadRequest();
            }

            _context.Entry(employee_Info).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_InfoExists(id))
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

        // POST: api/Employee_Info
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee_Info>> PostEmployee_Info(Employee_Info employee_Info)
        {
          if (_context.Employee_Info == null)
          {
              return Problem("Entity set 'Final_Codebase_EvaluationContext.Employee_Info'  is null.");
          }
            _context.Employee_Info.Add(employee_Info);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee_Info", new { id = employee_Info.EmployeeID }, employee_Info);
        }

        // DELETE: api/Employee_Info/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee_Info(int id)
        {
            if (_context.Employee_Info == null)
            {
                return NotFound();
            }
            var employee_Info = await _context.Employee_Info.FindAsync(id);
            if (employee_Info == null)
            {
                return NotFound();
            }

            _context.Employee_Info.Remove(employee_Info);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Employee_InfoExists(int id)
        {
            return (_context.Employee_Info?.Any(e => e.EmployeeID == id)).GetValueOrDefault();
        }
    }
}
