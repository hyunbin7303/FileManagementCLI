using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using Xunit;
using FileManager.Domain.Models;
using FileManager.Infrastructure.Repository;

namespace FileManager.Infrastructure.Tests
{
    public class DatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;
        public DbConnection Connection { get; }
        public ServiceProvider ServiceProvider { get; private set; }
        public DatabaseFixture()
        {
            var sb = new SqlConnectionStringBuilder()
            {
                DataSource = ".\\,1433",
                InitialCatalog = "myDataBase",
                UserID = "sa",
                Password = "Conestoga1",
                IntegratedSecurity = false,
                PersistSecurityInfo = true,
                //MultipleActiveResultSets=true
            };
            Connection = new SqlConnection(sb.ConnectionString);
            Seed();
            Connection.Open();
        }


        public FileDbContext CreateContext(DbTransaction transaction = null)
        {
            var option = new DbContextOptionsBuilder<FileDbContext>().UseSqlServer(Connection).Options;

            var context = new FileDbContext(option);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }
        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        var user = new User
                        {
                            UserId="test",
                        };

                        var file = new File
                        {
                            Name="testfile",
                            IsActive = false,
                            Status = FileStatus.Added,
                            Type = FileType.Image,
                            Remote=Domain.SaveEnvironment.Local,
                            User = user,
                        };

                        var folder = new Folder
                        {
                            Name="testfolder",
                            Path = "test/path",
                            Status = FolderStatus.Added,
                            Remote = Domain.SaveEnvironment.Local,
                            User = user,
                        };

                        var filefolder = new FileFolder { File = file,  Folder = folder };

                        context.Add(file);
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public void Dispose() => Connection.Dispose();
    }

    public class FileRepositoryTest : IClassFixture<DatabaseFixture>
    {
        DatabaseFixture Fixture { get; }
        public FileRepositoryTest(DatabaseFixture fixture) => Fixture = fixture;

        [Theory]
        [InlineData(1)]
        public void Shoud_Get_File_With_Id(int id)
        {
            using (var transaction = Fixture.Connection.BeginTransaction())
            {
                using (var context = Fixture.CreateContext(transaction))
                {
                    var repo = new FileRepository(context);
                    var file = repo.GetById(id);
                    Assert.Equal(Domain.SaveEnvironment.Local, file.Remote);
                    Assert.Equal(FileStatus.Added, file.Status);
                    Assert.Equal("testfile", file.Name);
                }
            }
        }
    }
}
