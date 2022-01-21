using FileManager.Domain;
using FileManager.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IFileService
    {
        IList<File> GetFiles();
        Task<File> GetFileById(int Id);
        bool UploadFileToDestination(StorageType module, object provider, string userId, string fileName, string path);
        IList<File> GetFilesByUserId(string userId);
        IList<File> GetFileByFileName(string fileName, string userId = null);
        Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken);
        Task CreateFolderInDirectory(string targetDirectory, string fileName);
        Task DeleteFile(string fileName, string userId);
        Task DeleteAll(string userId);
    }
}
