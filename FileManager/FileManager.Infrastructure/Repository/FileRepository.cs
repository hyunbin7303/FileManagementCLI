using FileManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Models;
namespace FileManager.Infrastructure.Repository
{
    public class FileRepository: Repository<File>, IFileRepository
    {
        public FileRepository(FileDbContext context) : base(context)
        {
            
        }
        public IList<File> GetByFileName(string fileName)
        {
            return _context.Set<File>().Where(x => x.FileName == fileName).ToList();
        }
        public IList<File> GetAllFilesContains(string fileContains) 
        {
            return _context.Set<File>().Where(x => x.FileName.Contains(fileContains)).ToList();
        }

        public IList<File> GetAllFilesWithPermission()
        {
            // TODO : Checking the permission.
            return null;
        }
    }
}
