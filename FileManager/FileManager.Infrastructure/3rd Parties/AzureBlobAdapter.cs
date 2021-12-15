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
    // Proxy Design Pattern : https://dotnettutorials.net/lesson/proxy-design-pattern/
    // https://darthpedro.net/2021/03/18/lesson-6-3-create-blob-storage-repository/

    public class AzureBlobAdapter : IBlobStorageAdapter
    {
        private BlobContainerClient _blobContainerClient;
        public AzureBlobAdapter(string connString, string containerName)
        {
            _blobContainerClient = new BlobContainerClient(connString, containerName);
            _blobContainerClient.CreateIfNotExists(PublicAccessType.BlobContainer);
        }

        public async Task<bool> UploadAsync(string localFilePath, string filePathWithName, string contentType)
        {

            var createResponse = await _blobContainerClient.CreateIfNotExistsAsync();
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                await _blobContainerClient.SetAccessPolicyAsync(PublicAccessType.Blob);

            BlobClient blobClient = _blobContainerClient.GetBlobClient(filePathWithName);
            await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots); 

            
            using FileStream uploadFileStream = File.OpenRead(localFilePath);
            var check = await blobClient.UploadAsync(uploadFileStream, new BlobHttpHeaders { ContentType = contentType });
            uploadFileStream.Close();
            return true;
        }

        public async Task<string> DownloadFileAsync(string filePathWithName, string destinationPath)
        { 
            BlobClient blobClient = _blobContainerClient.GetBlobClient(filePathWithName);
            if (await blobClient.ExistsAsync())
            {
                BlobDownloadInfo download = await blobClient.DownloadAsync();
                byte[] result = new byte[download.ContentLength];
                await download.Content.ReadAsync(result, 0, (int)download.ContentLength);

                // provide the file download location below            
                Stream file = File.OpenWrite(@"C:\" + destinationPath);
                var test = await blobClient.DownloadToAsync(file);
                Console.WriteLine("Download completed!" + test.ToString());
                return Encoding.UTF8.GetString(result);
            }
            return string.Empty;
        }
        public async Task<bool> Delete(string pathAndFileName)
        {
            BlobClient blobClient = _blobContainerClient.GetBlobClient(pathAndFileName);
            return await blobClient.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
        }

        public async Task<List<string>> ListBlobsFlatListing(int? segmentSize)
        {
            try
            {
                List<string> blobsStrlist = new List<string>();
                var resultSegment = _blobContainerClient.GetBlobsAsync().AsPages(default, segmentSize);
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

        public async Task<int> ReadAsync(BlobDownloadInfo download, byte[] buffer)
        {
            _ = download ?? throw new ArgumentNullException(nameof(download));
            return await download.Content.ReadAsync(buffer, 0, (int)download.ContentLength).ConfigureAwait(false);
        }

    }
}
