using FileManager.Domain;
using FileManager.Domain.Models;
using FileManager.Infrastructure;
using FileManager.Infrastructure._3rd_Parties;
using FileManager.Infrastructure.Helpers;
using FileManager.Infrastructure.Interfaces;
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
        private readonly IFileRepository _fileRepo;

        public FileService(ILogger<FileService> log, IFileRepository fileRepo)
        {
            _log = log;
            _fileRepo = fileRepo;
        }

        public Task CreateFolderInDirectory(string targetDirectory, string fileName)
        {
            // TODO : 
            throw new NotImplementedException();
        }

        public Task DeleteAll(string userId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFile(string fileName, string userId)
        {
            throw new NotImplementedException();
        }

        public IList<File> GetFileByFileName(string fileName, string userId = null)
        {
            return _fileRepo.GetByFileName(fileName).Where(x=>x.User.UserId == userId).ToList();
        }

        public async Task<File> GetFileById(int Id)
        {
            return await _fileRepo.FindByIdAsync(Id);
        }

        public IList<File> GetFiles()
        {
            return _fileRepo.GetAll().ToArray();
        }

        public IList<File> GetFilesByUserId(string userId)
        {
            /*var file = from f in _fileDbContext.Files
                       where f.OwnerId.Equals(userId)
                       select f;

            var files =  _fileDbContext.Files.Where(f => f.OwnerId == userId).ToList();
            return files;*/
            throw new NotImplementedException();

        }

        public Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool UploadFileToDestination(StorageType module, object provider, string userId, string fileName, string path)
        {
            switch(module)
            {
                case StorageType.GoogleDrive:
                    break;

                case StorageType.AzureBlobStorage:
                    var check = (CloudSetup)provider;
                    AzureBlobAdapter azureBlobAdapter = new AzureBlobAdapter(check.ConnString, check.ContainerName);
                    string pathWithFileName = $"{path}\\{fileName}";
                    string fileType = MimeTypeMap.GetMimeType(pathWithFileName);
                    if (azureBlobAdapter.UploadFile(pathWithFileName, $"{userId}|{fileName}", fileType))
                    {
                        File file = new File(fileName, userId, true, FileStatus.Added, fileType, StorageType.AzureBlobStorage, "OnlyUser",null);

                        GetFiles();
                        _fileRepo.Add(file);
                        var changed = _fileRepo.SaveChanges();
                        _log.LogInformation($"File:{fileName} is inserted to the Azure Blob.");
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
