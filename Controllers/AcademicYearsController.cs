using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    
    public class AcademicYearsController : ControllerBase
    {
        
        private readonly WebApplication1Context _context;

       
        public AcademicYearsController(WebApplication1Context context)
        {
            _context = context;
        }
        
        // GET: api/AcademicYear
        [HttpGet]
        public  List<AcademicYear> GetAcademicYear()
        {
            return  _context.AcademicYear.ToList();
        }

        // GET: api/AcademicYear/5
        [HttpGet("{id}")]
        public  AcademicYear GetAcademicYear(int id)
        {
            
            var academicYear =  _context.AcademicYear.Find(id);

            if (academicYear == null)
            {
                return null;
            }

            return academicYear;
        }

        // PUT: api/AcademicYear/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcademicYear(int id, AcademicYear academicYear)
        {
            if (id != academicYear.Id)
            {
                return BadRequest();
            }

            _context.Entry(academicYear).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcademicYearExists(id))
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

        // POST: api/AcademicYear
        [HttpPost]
        public  void PostAcademicYear([FromBody] AcademicYear academicYear)
        {
            try {
                _context.AcademicYear.Add(academicYear);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
            return;
        }

        // DELETE: api/AcademicYear/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAcademicYear(int id)
        {
            var academicYear = await _context.AcademicYear.FindAsync(id);
            if (academicYear == null)
            {
                return NotFound();
            }

            _context.AcademicYear.Remove(academicYear);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcademicYearExists(int id)
        {
            return _context.AcademicYear.Any(e => e.Id == id);
        }
    }
}
