using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    [Table("subject")]
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
