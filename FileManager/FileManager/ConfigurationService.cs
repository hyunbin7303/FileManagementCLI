using FileManager.Domain;
using FileManager.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly ILogger<ConfigurationService> _log;
        private readonly IConfiguration _config;
        public ConfigurationService(ILogger<ConfigurationService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }
        public void DatabaseSetup()
        {
            throw new NotImplementedException();
        }

        public CloudSetup GetCloudSetup()
        {
            CloudSetup cloudSetup = new CloudSetup(_config.GetValue<string>("UserId"));
            // Need to figure it out how to change below configuration setup into the one line.
            cloudSetup.ConnString = _config.GetValue<string>("MySettings:AzureStorageKey");
            cloudSetup.ContainerName = _config.GetValue<string>("MySettings:AzureContainerName");
            cloudSetup.DefaultFolder = _config.GetValue<string>("DefaultFolder");
            cloudSetup.UploadFilePath = _config.GetValue<string>("MySettings:AzureUploadFilePath");
            return cloudSetup;
        }
        

        public void Run()
        {
            for (int i = 0; i < _config.GetValue<int>("LoopTimes"); i++)
            {
                _log.LogInformation("Run number {runNumber}", i);
            }
        }
    }

}
