using Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Models;

namespace FileManager.Infrastructure.Interfaces
{
    public interface IFileRepository :IRepository<File>
    {
        IList<File> GetByFileName(string fileName);
        IList<File> GetAllFilesContains(string fileContains);
        IList<File> GetAllFilesWithPermission();
    }
}
