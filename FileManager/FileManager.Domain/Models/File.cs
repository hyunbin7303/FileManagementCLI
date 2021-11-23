using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileManager.Domain.Models
{
    public class File : Base
    {
        public string FileName { get; set; }
        public string Storage { get; set; }

        [ForeignKey("OwnerId")]
        public string OwnerId { get; set; }


        [Required]
        public bool IsActive { get; set; }
        [Required]
        public FileStatus Status { get; set; }
        [Required]
        public FileType Type { get; set; }
        [Required]
        public StorageType StorageType { get; set; }
        public User User { get; set; }
        public List<FileFolder> FileFolders { get; set; }

    }
    public enum FileStatus
    {
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
}
