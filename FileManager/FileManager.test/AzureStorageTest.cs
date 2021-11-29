﻿using FileManager.Infrastructure._3rd_Parties;
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
        public static IConfiguration _configuration;
        private static readonly string _azureConnectionStr = "DefaultEndpointsProtocol=https;AccountName=filesystemmanager;AccountKey=mFvs+bFBaEE1POpSKN8u0V1V/iPCw8W3NtRT6xkOtoEZhyh5kTcHdgGY9i9xeseOwxlXFAhIIqILkfk7s3t+6w==;BlobEndpoint=https://filesystemmanager.blob.core.windows.net/;QueueEndpoint=https://filesystemmanager.queue.core.windows.net/;TableEndpoint=https://filesystemmanager.table.core.windows.net/;FileEndpoint=https://filesystemmanager.file.core.windows.net/;";

        [SetUp]
        public void Setup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [Test]
        public async Task GetListsAsyncTest()
        {
            AzureBlobAdapter azureBlobRepository = new AzureBlobAdapter("DefaultEndpointsProtocol=https;AccountName=filesystemmanager;AccountKey=mFvs+bFBaEE1POpSKN8u0V1V/iPCw8W3NtRT6xkOtoEZhyh5kTcHdgGY9i9xeseOwxlXFAhIIqILkfk7s3t+6w==;BlobEndpoint=https://filesystemmanager.blob.core.windows.net/;QueueEndpoint=https://filesystemmanager.queue.core.windows.net/;TableEndpoint=https://filesystemmanager.table.core.windows.net/;FileEndpoint=https://filesystemmanager.file.core.windows.net/;", "container01");
            await azureBlobRepository.Upload("C:\\Kevin\\TestFolder\\JsonTest.json", "JsonTest.json", "application/json");
        }
        [Test]
        public async Task ListBlobsFlatListing_ReturnListString()
        {
            AzureBlobAdapter azureBlobRepository = new AzureBlobAdapter("DefaultEndpointsProtocol=https;AccountName=filesystemmanager;AccountKey=mFvs+bFBaEE1POpSKN8u0V1V/iPCw8W3NtRT6xkOtoEZhyh5kTcHdgGY9i9xeseOwxlXFAhIIqILkfk7s3t+6w==;BlobEndpoint=https://filesystemmanager.blob.core.windows.net/;QueueEndpoint=https://filesystemmanager.queue.core.windows.net/;TableEndpoint=https://filesystemmanager.table.core.windows.net/;FileEndpoint=https://filesystemmanager.file.core.windows.net/;", "container01");
            var check = await azureBlobRepository.ListBlobsFlatListing(1);
            Assert.IsNotNull(check);
        }
        [Test]
        public void OpenBlobClient_ReturnBlobClient()
        {
            AzureBlobAdapter adapter = new AzureBlobAdapter("DefaultEndpointsProtocol=https;AccountName=filesystemmanager;AccountKey=mFvs+bFBaEE1POpSKN8u0V1V/iPCw8W3NtRT6xkOtoEZhyh5kTcHdgGY9i9xeseOwxlXFAhIIqILkfk7s3t+6w==;BlobEndpoint=https://filesystemmanager.blob.core.windows.net/;QueueEndpoint=https://filesystemmanager.queue.core.windows.net/;TableEndpoint=https://filesystemmanager.table.core.windows.net/;FileEndpoint=https://filesystemmanager.file.core.windows.net/;", "container01");
            var check = adapter.OpenBlobClient(_azureConnectionStr, "container01", "");
            Assert.IsNotNull(check);
        }
    }
}