﻿using FileManager.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileManager.Service
{
    public class FileService : IFileService
    {
        //TODO : SQL Connection. 
        private readonly string _folderDirectory = "c://";
        public IList<string> GetFiles()
        {
            var files = Directory.GetFiles(_folderDirectory).ToList();
            return files;
        }
        public Task<File> GetFileByFileName(string fileName)
        {
            var get = GetFiles();
            return null;
        }
        public Task<File> GetFileById(int Id)
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

        public Task CreateFolderInDirectory(string targetDirectory)
        {
            throw new NotImplementedException();
        }
    }
}
