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
    public class AzureStorageClient
    {
        public AzureStorageClient()
        {
            Setup();
        }
        private void Setup()
        {

        }


        public static void UploadingBlob()
        {
            string connectionString = "<connection_string>";
            string containerName = "sample-container";
            string blobName = "sample-blob";
            string filePath = "sample-file";

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.Create();

            // Get a reference to a blob named "sample-file" in a container named "sample-container"
            BlobClient blob = container.GetBlobClient(blobName);

            // Upload local file
            blob.Upload(filePath);
        }

        public static void DownloadingBlob()
        {
            // Get a temporary path on disk where we can download the file
            string downloadPath = "hello.jpg";

            // Download the public blob at https://aka.ms/bloburl
            new BlobClient(new Uri("https://aka.ms/bloburl")).DownloadTo(downloadPath);
        }
        public void EnumeratingBlob()
        {
            // Get a connection string to our Azure Storage account.
            string connectionString = "<connection_string>";
            string containerName = "sample-container";
            string filePath = "hello.jpg";

            // Get a reference to a container named "sample-container" and then create it
            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            container.Create();

            // Upload a few blobs so we have something to list
            container.UploadBlob("first", File.OpenRead(filePath));
            container.UploadBlob("second", File.OpenRead(filePath));
            container.UploadBlob("third", File.OpenRead(filePath));

            // Print out all the blob names
            foreach (BlobItem blob in container.GetBlobs())
            {
                Console.WriteLine(blob.Name);
            }
        }

        public static void CreateContainer(string containerName)
        {

        }
    }
}
