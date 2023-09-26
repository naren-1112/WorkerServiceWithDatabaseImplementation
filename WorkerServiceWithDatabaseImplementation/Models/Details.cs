using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceWithDatabaseImplementation.Models
{
    public class Details
    {
        [Key]
        [Required]
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
    }
}
