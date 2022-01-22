using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain
{
    public class CloudProvider : IEquatable<CloudProvider>
    {
        public StorageType StorageTypeId { get; set; }

        public string Name { get; set; }

        public string SyncFolder { get; set; }

        public override int GetHashCode()
        {
            return $"{StorageTypeId}|{SyncFolder}".GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is CloudProvider other)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }

        public bool Equals(CloudProvider other)
        {
            return other != null && other.StorageTypeId == StorageTypeId && other.SyncFolder == SyncFolder;
        }
    }
}
