using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileManager.Domain.Models
{
    public class File : Base
    {
        public File(){}
        public File(string fileName, string ownerId, bool isActive, FileStatus status, string fileType, StorageType storageType, string fileAccessRules, User user)
        {
            FileName = fileName;
            OwnerId = ownerId;
            IsActive = isActive;
            Status = status;
            FileType = fileType;
            StorageType = storageType;
            FileAccessRules = fileAccessRules;
            User = user;
        }

        public string FileName { get; set; }
        public string OwnerId { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public FileStatus Status { get; set; }
        public string FileType { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public StorageType StorageType { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string FileAccessRules { get; set; } 
        public User User { get; set; }
        public List<FileFolder> FileFolders { get; set; }


    }
}
