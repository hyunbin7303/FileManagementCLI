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
        public File GetByFileName(string fileName); 
    }
}
