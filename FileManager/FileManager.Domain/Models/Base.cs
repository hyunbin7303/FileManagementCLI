using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain.Models
{
    public class Base
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;
        public DateTime? Deleted { get; set; }
        public DateTime? Modified { get; set; }
    }
}
