using FileManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructure
{
    public class FileDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }

        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }

    public class FileContextDesignFactory : IDesignTimeDbContextFactory<FileDbContext>
    {
        public FileDbContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }

}
