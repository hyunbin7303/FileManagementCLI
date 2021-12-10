using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructure._3rd_Parties
{
    public interface IBlobStorageAdapter
    {
        BlobClient OpenBlobClient(string connection, string containerName, string blobName);
        Task<BlobDownloadInfo> DownloadAsync(BlobClient client);
        public Task<string> Download(string filePathWithName);
        Task<bool> Upload(string localFilePath, string filePathWithName, string contentType);
        Task<int> ReadAsync(BlobDownloadInfo download, byte[] buffer);
        Task<bool> Delete(string pathAndFileName);

    }
}
