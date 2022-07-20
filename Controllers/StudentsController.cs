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
    public class StudentsController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public StudentsController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public List<Student> GetStudents()
        {
            return  _context.Student.ToList();
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public object GetStudent(int id)
        {
            var student =  _context.Student.Find(id);
            
            if (student == null)
            {
                return NotFound();
            }
            
            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  object PutStudent(int id, Student student)
        {
            
            
            if (id != student.Id)
            {
                return BadRequest();
            }
            

            _context.Entry(student).State = EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        
        [HttpPost]
        public  object  PostStudent(Student student)
        {
            try
            {
                
                _context.Student.Add(student);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public  object DeleteStudent(int id)
        {
            var student =  _context.Student.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            try
            {
                _context.Student.Remove(student);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }
            return BadRequest();
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }
        private string GetStudentAcademicYear(int id)
        {
            return _context.AcademicYear.Find(id).Year;
        }
    }
}
