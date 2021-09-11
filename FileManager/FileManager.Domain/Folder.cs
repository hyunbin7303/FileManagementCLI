using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain
{
    public class Folder : Base
    {
        public string Path { get; set; }
        public FolderStatus Status { get; set; }
        public FolderAttributes Attributes { get; set; }
        public int OwnerId { get; set; }
    }
    public enum FolderStatus
    {

    }
    public class FolderAttributes
    {

    }
}
