using FileManager.Domain;
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
        public Task<FileModel> GetFileByFileName(string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<FileModel> GetFileById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<FileModel>> GetFiles()
        {
            throw new NotImplementedException();
        }

        public Task<IList<FileModel>> GetFilesByUserInfo(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
