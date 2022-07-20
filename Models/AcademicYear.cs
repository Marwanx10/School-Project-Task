using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("AcademicYear")]
    public class AcademicYear
    {
        public int Id { get; set; }
        public string Year { get; set; }
    }
}
