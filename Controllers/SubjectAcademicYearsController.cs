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
    public class SubjectAcademicYearsController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public SubjectAcademicYearsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/SubjectAcademicYears
        [HttpGet]
        public  List<SubjectAcademicYear> GetSubjectAcademicYear()
        {
            return _context.SubjectAcademicYear.ToList();
        }

        // GET: api/SubjectAcademicYears/5
        [HttpGet("{id}")]
        public  object GetSubjectAcademicYear(int id)
        {
            var subjectAcademicYear =  _context.SubjectAcademicYear.Find(id);

            if (subjectAcademicYear == null)
            {
                return NotFound();
            }

            return subjectAcademicYear;
        }

        // PUT: api/SubjectAcademicYears/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public object PutSubjectAcademicYear(int id, SubjectAcademicYear subjectAcademicYear)
        {
            if (id != subjectAcademicYear.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectAcademicYear).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectAcademicYearExists(id))
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

        // POST: api/SubjectAcademicYears
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public  object PostSubjectAcademicYear(SubjectAcademicYear subjectAcademicYear)
        {
            try {
                _context.SubjectAcademicYear.Add(subjectAcademicYear);
                _context.SaveChanges();

                return Ok();
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
        }

        // DELETE: api/SubjectAcademicYears/5
        [HttpDelete("{id}")]
        public object DeleteSubjectAcademicYear(int id)
        {
            var subjectAcademicYear =  _context.SubjectAcademicYear.Find(id);
            if (subjectAcademicYear == null)
            {
                return NotFound();
            }

            _context.SubjectAcademicYear.Remove(subjectAcademicYear);
            _context.SaveChanges();

            return NoContent();
        }

        private bool SubjectAcademicYearExists(int id)
        {
            return _context.SubjectAcademicYear.Any(e => e.Id == id);
        }
    }
}
