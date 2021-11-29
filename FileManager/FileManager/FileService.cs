using FileManager.Domain;
using FileManager.Domain.Models;
using FileManager.Infrastructure;
using FileManager.Infrastructure._3rd_Parties;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace FileManager
{
    public class FileService : IFileService
    {
        //TODO : SQL Connection. 
        //private readonly string _folderDirectory = "c://";
        private readonly ILogger<FileService> _log;
        private readonly FileDbContext _fileDbContext;

        public FileService(ILogger<FileService> log)
        {
            _log = log;
        }

        public FileService(FileDbContext dbContext)
        {
            _fileDbContext = dbContext;
        }

        public Task CreateFolderInDirectory(string targetDirectory)
        {
            throw new NotImplementedException();
        }

        public Task<File> GetFileByFileName(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<File> GetFileById(int Id)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetFiles()
        {
            throw new NotImplementedException();
        }

        public Task<IList<File>> GetFilesByUserInfo(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UploadFilesToDestination(StorageType module, object provider, string userId, string fileName, string path)
        {
            switch(module)
            {
                case StorageType.GoogleDrive:
                    break;

                case StorageType.AzureBlobStorage:
                    var check = (CloudSetup)provider;
                    AzureBlobAdapter azureBlobAdapter = new AzureBlobAdapter(check.ConnString, check.ContainerName);

                    var files = WinFileManageHelper.GetAllFiles(path);
                    foreach(var file in files)
                    {
                        await azureBlobAdapter.Upload(path, file.Name, file.Attributes.ToString());
                        // TODO : Need to remove file from the directory
                        // TODO : Need to update the data(record) in the sql server. 
                        //_fileDbContext.Files.Add(file);
                        _log.LogInformation($"File:{file.FullName} is inserted to the Azure Blob.");

                    }
                    break;

                default:
                    _log.LogInformation("Invalid Storage Type : " + module);
                    break;
            }

            return false;
        }
    }
}
