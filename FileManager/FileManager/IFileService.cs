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
        IList<File> GetFilesByStorageType(StorageType storageType);
        Task<File> GetFileById(int Id);
        bool UploadFileToDestination(StorageType module,string fileName, string path);
        IList<File> GetFilesByUserId(string userId = null);
        IList<File> GetFileByFileName(string fileName, string userId = null);
        Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken);
        Task CreateFolderInDirectory();
        Task DeleteFile(string fileName, string userId);
        Task DeleteAll(string type =null);
    }
}
