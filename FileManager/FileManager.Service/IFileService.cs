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
        Task<IList<FileModel>> GetFiles();
        Task<FileModel> GetFileById(int Id);
        Task<FileModel> GetFileByFileName(string fileName);
        Task<IList<FileModel>> GetFilesByUserInfo(string userId);
        Task<bool> IsFileUnique(string fileName, CancellationToken cancellationToken);
    }
}
