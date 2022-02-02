using FileManager.Infrastructure;
using FileManager.Infrastructure.Interfaces;
using FileManager.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.test.ServiceLayerTest
{
    public class FileServiceTest
    {
        private  ILogger<FileService> _log;
        private IConfigurationService _configurationService;
        private IFileService _fileService;
        private IFileRepository _fileRepo;
        private IFolderRepository _folderRepo;
        private IUserRepository _userRepo;
        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FileDbContext>()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FileManager;Integrated Security=True");
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            _log = factory.CreateLogger<FileService>();

            FileDbContext dbContext = new FileDbContext(optionsBuilder.Options);
            _fileRepo = new FileRepository(dbContext);
            _folderRepo = new FolderRepository(dbContext);
            _userRepo = new UserRepository(dbContext);
            _fileService = new FileService(_log, _configurationService, _fileRepo, _folderRepo, _userRepo);


        }
        [Test]
        public async Task DownloadFile_GetFileToDirectory()
        {
        }
    }
}
