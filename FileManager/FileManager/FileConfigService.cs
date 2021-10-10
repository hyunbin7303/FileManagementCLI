using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class FileConfigService
    {
    }
    public interface ITestingService
    {
        public void Run();
    }
    public class TestingService : ITestingService
    { 
        private readonly ILogger<TestingService> _log;
        private readonly IConfiguration _config;
        public TestingService(ILogger<TestingService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
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
