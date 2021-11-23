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
        Task<int> ReadAsync(BlobDownloadInfo download, byte[] buffer);

    }
}
