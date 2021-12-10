using FileManager.Domain;
using FileManager.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FileManager
{
    public interface IFileService
    {
        IList<string> GetFiles();
        Task<File> GetFileById(int Id);
        Task<File> GetFileByFileName(string fileName);
        Task<bool> UploadFilesToDestination(StorageType module, object provider, string userId, string fileName, string path);
        IList<File> GetFilesByUserInfo(string userId);
        Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken);
        Task CreateFolderInDirectory(string targetDirectory, string fileName);
    }
}
