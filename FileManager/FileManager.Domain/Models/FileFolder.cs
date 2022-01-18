using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain.Models
{
    public class FileFolder
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        public File File { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }

    }
}
