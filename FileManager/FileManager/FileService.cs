﻿using FileManager.Domain;
using FileManager.Domain.Models;
using FileManager.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace FileManager
{
#pragma warning disable CS0436 // Type conflicts with imported type
    public class FileService : IFileService
#pragma warning restore CS0436 // Type conflicts with imported type
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

        public Task<bool> UploadFileToDestination(string fileId, string destination)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UploadFileToDestination(StorageType module, string userId, string fileName, string path)
        {
            switch(module)
            {
                case StorageType.GoogleDrive:
                    break;

                case StorageType.AzureBlobStorage:
                    break;

                default:
                    _log.LogInformation("Invalid Storage Type : " + module);
                    break;
            }

            return Task.FromResult(false);
        }
    }
}
