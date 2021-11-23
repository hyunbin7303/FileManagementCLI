using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain
{
    public enum StorageType
    {
        Local,
        AzureBlobStorage,
        GoogleDrive,
        Dropbox
    }
}
