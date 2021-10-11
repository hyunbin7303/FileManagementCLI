using System;

namespace FileManager.Domain.Models
{
    public class File : Base
    {
        public bool IsActive { get; set; }
        public FileStatus Status { get; set; }
        public FileType Type { get; set; }
        public int OwnerId { get; set; }
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
    public class FileAttributes
    {

    }
}
