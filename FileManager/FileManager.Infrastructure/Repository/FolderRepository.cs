using FileManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Models;
namespace FileManager.Infrastructure.Repository
{
    public class FolderRepository : Repository<Folder>, IFolderRepository
    {
        public FolderRepository(FileDbContext context) : base(context)
        {
            
        }

        public IList<Folder> GetFoldersByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
