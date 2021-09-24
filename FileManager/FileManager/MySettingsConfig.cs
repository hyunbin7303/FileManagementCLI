using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class MySettingsConfig
    {
        private readonly IConfiguration configuration;
        public MySettingsConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string AccountName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

    }
}
