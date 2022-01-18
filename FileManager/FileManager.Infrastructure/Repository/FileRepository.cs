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
        public File GetByFileName(string fileName)
        {
            return _context.Set<File>().FirstOrDefault(f => f.FileName == fileName);
            //_fileDbContext.Files.FirstOrDefault(f => f.FileName == fileName);
        }
    }
}
