using FileManager.Domain.Models;
using System;
using System.Collections.Generic;
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
    }
}
