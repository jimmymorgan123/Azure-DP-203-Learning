using System;
using Microsoft.Extensions.Configuration;
using System.IO;
// Azure Storage Blobs client library for .NET
using Azure.Storage.Blobs; 

namespace PhotoSharingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            //get the Azure Storage connection string and create the BlobContainerClient object
            var configuration = builder.Build();

            var connectionString = configuration.GetConnectionString("StorageAccount");
            string containerName = "photos";

            BlobContainerClient container = new BlobContainerClient(connectionString, containerName);
            
            container.CreateIfNotExists();
        }
    }
}
