using Azure;
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
    // TODO : Unit test + Understand Proxy Design Pattern.
    //Proxy Design Pattern : https://dotnettutorials.net/lesson/proxy-design-pattern/
    //https://darthpedro.net/2021/03/18/lesson-6-3-create-blob-storage-repository/
    public class AzureBlobAdapter : IBlobStorageAdapter
    {
        private BlobContainerClient _blobClient;
        public AzureBlobAdapter(string connString, string containerName)
        {
            _blobClient = new BlobContainerClient(connString, containerName);
            _blobClient.CreateIfNotExists(PublicAccessType.BlobContainer);
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

        public async Task<List<string>> ListBlobsFlatListing(int? segmentSize)
        {
            try
            {
                List<string> blobsStrlist = new List<string>();
                var resultSegment = _blobClient.GetBlobsAsync().AsPages(default, segmentSize);
                await foreach (Page<BlobItem> blobPage in resultSegment)
                {
                    foreach (BlobItem blobItem in blobPage.Values)
                    {
                        blobsStrlist.Add(blobItem.Name);
                    }
                }
                return blobsStrlist;
            }
            catch (RequestFailedException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }
        }

        public BlobClient OpenBlobClient(string connection, string containerName, string blobName)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(connection);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);
            return containerClient.GetBlobClient(blobName);
        }

        public async Task<BlobDownloadInfo> DownloadAsync(BlobClient client)
        {
            _ = client ?? throw new ArgumentNullException(nameof(client));
            return await client.DownloadAsync().ConfigureAwait(false);
        }

        public async Task<int> ReadAsync(BlobDownloadInfo download, byte[] buffer)
        {
            _ = download ?? throw new ArgumentNullException(nameof(download));
            return await download.Content.ReadAsync(buffer, 0, (int)download.ContentLength).ConfigureAwait(false);
        }
    }
}
