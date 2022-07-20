using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("Student")]
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Faculty Faculty { get; set; }

        [ForeignKey("AcademicYear")]
        public int AcademicYearId { get; set; }
        
    }

    public enum Faculty
    {
        Engineering,
        ComputerScience,
        Commerce,
        Law
    }
}
