using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileManager.Domain.Models
{
    public class File : Base
    {
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public FileStatus Status { get; set; }
        [Required]
        public FileType Type { get; set; }
        [Required]
        public SaveEnvironment Remote { get; set; }

        public int OwnerId { get; set; }
        Added,
        Modifed,
        Deleted
    }
    public enum FileType
    {
        Unkown,
        Text,
        Image,
        Compressed,
    }
    public class FileAttributes
    {

    }
}
