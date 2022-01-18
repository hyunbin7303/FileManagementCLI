using FileManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructure
{
    public partial class FileDbContext : DbContext
    {
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Folder> Folders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<FileFolder> FileFolders { get; set; }


        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if option builder is not configured, then use sqlserver as default database
            // this should be configured in Infrastructure\DIExtension
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FileManager;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileFolder>()
                .HasKey(ff => new { ff.FileId, ff.FolderId });

            modelBuilder.Entity<FileFolder>()
                .HasOne(ff => ff.File)
                .WithMany(f => f.FileFolders)
                .HasForeignKey(ff => ff.FileId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FileFolder>()
                .HasOne(ff => ff.Folder)
                .WithMany(f => f.FileFolders)
                .HasForeignKey(ff => ff.FolderId)
                .OnDelete(DeleteBehavior.NoAction);

            OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

    public class FileContextDesignFactory : IDesignTimeDbContextFactory<FileDbContext>
    {
        public FileDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
            var builder = new DbContextOptionsBuilder<FileDbContext>();
            var connectionString = configuration.GetConnectionString("SQLServerConnection");
            builder.UseSqlServer(connectionString);
            return new FileDbContext(builder.Options);
        }
    }

}
