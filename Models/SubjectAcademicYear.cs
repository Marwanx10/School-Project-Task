using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class SubjectAcademicYear
    {
        public int Id { get; set; }

        [ForeignKey("AcademicYear")]
        public int AcademicYearId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
    }
}
