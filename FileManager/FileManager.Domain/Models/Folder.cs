using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain.Models
{
    public class Folder : Base
    {
        [Required]
        public string Path { get; set; }
        [Required]
        public FolderStatus Status { get; set; }
        [Required]
        public SaveEnvironment Remote { get; set; }

        public int OwnerId { get; set; }
        [ForeignKey("OwnerId")]
        public User User { get; set; }


        public List<FileFolder> FileFolders { get; set; }
    }
    public enum FolderStatus
    {
        Added,
        Modifed,
        Deleted
    }
}
