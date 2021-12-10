using FileManager.Infrastructure._3rd_Parties;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.test
{
    public class AzureStorageTest
    {
        private static readonly string _azureConnectionStr = "DefaultEndpointsProtocol=https;AccountName=filesystemmanager;AccountKey=mFvs+bFBaEE1POpSKN8u0V1V/iPCw8W3NtRT6xkOtoEZhyh5kTcHdgGY9i9xeseOwxlXFAhIIqILkfk7s3t+6w==;BlobEndpoint=https://filesystemmanager.blob.core.windows.net/;QueueEndpoint=https://filesystemmanager.queue.core.windows.net/;TableEndpoint=https://filesystemmanager.table.core.windows.net/;FileEndpoint=https://filesystemmanager.file.core.windows.net/;";

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task Upload_ReturnTrueIfSuccess()
        {
            AzureBlobAdapter azureBlobRepository = new AzureBlobAdapter(_azureConnectionStr, "container01");
            var check = await azureBlobRepository.Upload("C:\\Kevin\\TestFolder\\JsonTest.json", "Kevin.json", "application/json");
            Assert.IsTrue(check);
        }


        [Test]
        public async Task ListBlobsFlatListing_ReturnListString()
        {
            AzureBlobAdapter azureBlobRepository = new AzureBlobAdapter(_azureConnectionStr, "container01");
            var check = await azureBlobRepository.ListBlobsFlatListing(1);
            Assert.IsNotNull(check);
        }
        [Test]
        public void OpenBlobClient_ReturnBlobClient()
        {
            AzureBlobAdapter adapter = new AzureBlobAdapter(_azureConnectionStr, "container01");
            var check = adapter.OpenBlobClient(_azureConnectionStr, "container01", "");
            Assert.IsNotNull(check);
        }
        [Test]
        public async Task Download_ReturnFile()
        {
            AzureBlobAdapter adapter = new AzureBlobAdapter(_azureConnectionStr, "container01");
            var check = await adapter.Download("Kevin.json");
            Assert.IsNotNull(check);
        }

    }
}
