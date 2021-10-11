using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Infrastructure._3rd_Parties
{
    public class AzureBlobRepository
    {
        private BlobContainerClient _blobClient;
        public AzureBlobRepository(string connString, string containerName)
        {
            _blobClient = new BlobContainerClient(connString, containerName);
            _blobClient.CreateIfNotExists(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
        }

        public async Task Upload(string localFilePath, string filePathWithName, string contentType)
        {
            BlobClient blobClient = _blobClient.GetBlobClient(filePathWithName);
            using FileStream uploadFileStream = File.OpenRead(localFilePath);
            await blobClient.UploadAsync(uploadFileStream, new BlobHttpHeaders { ContentType = contentType });
            uploadFileStream.Close();
        }

        public async Task<string> Download(string filePathWithName)
        {
            BlobClient blobClient = _blobClient.GetBlobClient(filePathWithName);
            if (await blobClient.ExistsAsync())
            {
                BlobDownloadInfo download = await blobClient.DownloadAsync();
                byte[] result = new byte[download.ContentLength];
                await download.Content.ReadAsync(result, 0, (int)download.ContentLength);

                return Encoding.UTF8.GetString(result);
            }
            return string.Empty;
        }
        public async Task<bool> Delete(string pathAndFileName)
        {
            BlobClient blobClient = _blobClient.GetBlobClient(pathAndFileName);
            return await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }
    }
}
