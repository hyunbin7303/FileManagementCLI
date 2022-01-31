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
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace FileManager
{
    public class FileService : IFileService
    {
        //private readonly string _folderDirectory = "c://";
        private readonly ILogger<FileService> _log;
        private readonly IFileRepository _fileRepo;
        private readonly IFolderRepository _folderRepo;
        private readonly IUserRepository _userRepo;
        private readonly IConfigurationService _configurationService;

        private string _userId;
        private CloudSetup _cloudSetup;
        public FileService(ILogger<FileService> log, IConfigurationService configurationService, IFileRepository fileRepo, IFolderRepository folderRepo, IUserRepository userRepo)
        {
            _log = log;
            _fileRepo = fileRepo;
            _folderRepo = folderRepo; 
            _userRepo = userRepo;
            _configurationService = configurationService;
            _userId = _configurationService.GetUserId();
            _cloudSetup = _configurationService.GetCloudSetup();
        }

        public Task CreateFolderInDirectory()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAll(string type = null)
        {
            var user = _userRepo.GetUserByUserId(_userId);
            if(user == null)
            {
            }
            //_fileRepo.RemoveRange()
            AzureBlobAdapter azureBlobAdapter = new AzureBlobAdapter(_cloudSetup.ConnString, _cloudSetup.ContainerName);
            var fileList = GetFilesByUserId();
            foreach(var file in fileList)
            {
                await azureBlobAdapter.DeleteFileAsync(file.StoredFileName());
            }
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
            return _fileRepo.GetAll().ToList();
        }

        public IList<File> GetFilesByStorageType(StorageType storageType)
        {
            throw new NotImplementedException();
        }

        public IList<File> GetFilesByUserId(string userId = null)
        {
            if(userId == null)
            {
                Expression<Func<User, bool>> predicate = x => x.UserId == userId;
                _userRepo.Get(predicate);

            }
            //return files;
            return null;
        }

        public Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public bool UploadFileToDestination(StorageType module, string fileName, string path)
        {
            switch(module)
            {
                case StorageType.GoogleDrive:
                    break;

                case StorageType.AzureBlobStorage:
                    AzureBlobAdapter azureBlobAdapter = new AzureBlobAdapter(_cloudSetup.ConnString, _cloudSetup.ContainerName);
                    string pathWithFileName = $"{path}\\{fileName}";
                    string fileType = MimeTypeMap.GetMimeType(pathWithFileName);
                    if (azureBlobAdapter.UploadFile(pathWithFileName, $"{_userId}|{fileName}", fileType))
                    {
                        File file = new File(fileName, _userId, true, FileStatus.Added, fileType, StorageType.AzureBlobStorage, "OnlyUser",null);
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

        public bool DownloadFileFromCloud(StorageType storage, string fileName)
        {
            switch (storage)
            {
                case StorageType.GoogleDrive:
                    break;

                case StorageType.AzureBlobStorage:
                    AzureBlobAdapter azureBlobAdapter = new AzureBlobAdapter(_cloudSetup.ConnString, _cloudSetup.ContainerName);
                    azureBlobAdapter.DownloadFileAsync($"{_userId}|{fileName}", "");
                    //string pathWithFileName = $"{path}\\{fileName}";
                    //string fileType = MimeTypeMap.GetMimeType(pathWithFileName);
                    //if (azureBlobAdapter.UploadFile(pathWithFileName, $"{userId}|{fileName}", fileType))
                    //{
                    //    File file = new File(fileName, userId, true, FileStatus.Added, fileType, StorageType.AzureBlobStorage, "OnlyUser", null);
                    //    _fileRepo.Add(file);
                    //    var changed = _fileRepo.SaveChanges();
                    //    _log.LogInformation($"File:{fileName} is inserted to the Azure Blob.");
                    //}
                    break;

                default:
                    break;
            }

            return false;
        }
    }
}
