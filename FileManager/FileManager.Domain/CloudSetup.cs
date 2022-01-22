using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Domain
{
    public class CloudSetup
    {
        public CloudSetup() {}
        public CloudSetup(string userId)  
        {
            UserId = userId; 
        }
        public string UserId { get; set; }
        public string ConnString { get; set; }
        public string ContainerName { get; set; }
        public string DefaultFolder { get; set; }
        public string UploadFilePath { get; set; }

    }
}
