using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public string Permission { get; set; }
        public DateTimeOffset ModifiedDate { get; set; }

        public List<File> Files { get; set; }
        public List<Folder> Folders { get; set; }
    }
}
