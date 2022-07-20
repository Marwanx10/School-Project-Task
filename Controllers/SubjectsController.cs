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
    public class SubjectsController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public SubjectsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/Subjects
        [HttpGet]
        public  List<Subject> GetSubject()
        {
            return _context.Subject.ToList();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public object GetSubject(int id)
        {
            var subject = _context.Subject.Find(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public object PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            _context.Entry(subject).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public object PostSubject(Subject subject)
        {
            _context.Subject.Add(subject);
            _context.SaveChanges();

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            try
            {
                _context.Subject.Remove(subject);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception) {
                return NoContent();
            }
            
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.Id == id);
        }
    }
}
