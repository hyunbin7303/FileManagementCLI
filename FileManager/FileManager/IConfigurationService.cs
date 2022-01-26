
using FileManager.Domain;
using FileManager.Domain.Models;

namespace FileManager
{
    public interface IConfigurationService
    {
        public void Run();
        public void DatabaseSetup();
        CloudSetup GetCloudSetup();
        string GetUserId();
    }

}
