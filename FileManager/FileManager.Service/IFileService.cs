using FileManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IFileService
    {
        IList<string> GetFiles();
        Task<FileModel> GetFileById(int Id);
        Task<FileModel> GetFileByFileName(string fileName);

        Task<bool> UploadFileToDestination(string fileId, string destination);
        Task<IList<FileModel>> GetFilesByUserInfo(string userId);
        Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken);

        Task CreateFolderInDirectory(string targetDirectory);
    }
}
