using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class FileConfigService : IFileConfigService
    {
        private readonly ILogger<FileConfigService> _log;
        private readonly IConfiguration _config;
        public FileConfigService(ILogger<FileConfigService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }
        public void DatabaseSetup()
        {
            throw new NotImplementedException();
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
