using FileManager.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManager.Domain.Models;
using System.Linq.Expressions;

namespace FileManager.Infrastructure.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FileDbContext context):base(context)
        {

        }

        public User GetUserByUserId(string userId)
        {
            Expression<Func<User, bool>> predicate = x => x.UserId == userId;
            return Get(predicate).FirstOrDefault();
        }
    }
}
