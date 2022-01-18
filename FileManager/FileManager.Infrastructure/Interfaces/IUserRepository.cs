using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using FileManager.Domain.Models;

namespace FileManager.Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        
    }
}
