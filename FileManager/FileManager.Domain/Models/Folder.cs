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
        public string FolderName { get; set; }
        public string OwnerId { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public FolderStatus Status { get; set; }
        [Required]
        public StorageType Remote { get; set; }
        [ForeignKey("OwnerId")]
        public User User { get; set; }
        public List<FileFolder> FileFolders { get; set; }
    }
    public enum FolderStatus
    {

    }
}
