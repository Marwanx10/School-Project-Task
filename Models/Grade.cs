using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
   
    [Table("Grade")]
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

    }
}
