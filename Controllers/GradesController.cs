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
    public class GradesController : ControllerBase
    {
        private readonly WebApplication1Context _context;

        public GradesController(WebApplication1Context context)
        {
            _context = context;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public List<Grade> Get()
        {
            return _context.Grade.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Grade Get(int id)
        {
            return _context.Grade.Find(id);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public object Post([FromBody] Grade grade)
        {
            try
            {
                _context.Grade.Add(grade);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public object Put(int id, [FromBody] Grade grade)
        {
            if (id != grade.Id)
            {
                return BadRequest();
            }
            _context.Entry(grade).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return Ok();
            }catch(Exception e)
            {
                return BadRequest();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            var grade = _context.Grade.Find(id);
            if (grade == null)
            {
                return BadRequest();
            }
            try {
                _context.Grade.Remove(grade);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            
        }

        public override bool Equals(object obj)
        {
            return obj is GradesController controller &&
                   EqualityComparer<WebApplication1Context>.Default.Equals(_context, controller._context);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
