using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameASU.Controller
{
    public class BlobStorageAccess
    {
        private String Reference { get; set; }

        // Retrieve storage account from connection string.
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));

        public BlobStorageAccess(string reference){Reference = reference;}

        public CloudBlobClient GetClient()
        {
            return storageAccount.CreateCloudBlobClient();
        }

        public CloudBlobContainer GetContainer()
        {
            return GetClient().GetContainerReference(Reference);
        }

        public List<CloudBlockBlob> ListBlobs()
        {
            List<CloudBlockBlob> blobList = new List<CloudBlockBlob>();
            CloudBlobContainer container = GetContainer();
            // Loop over items within the container and output the length and URI.
            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
                if (item.GetType() == typeof(CloudBlockBlob))
                {
                    CloudBlockBlob blob = (CloudBlockBlob)item;
                    blobList.Add(blob);
                }
            }

            return blobList;
        }

        public CloudBlockBlob GetBlob(string blobName)
        {
            return (CloudBlockBlob)GetContainer().GetBlockBlobReference(blobName);
        }

        public CloudBlockBlob DownloadBlob(string blobName)
        {
            return GetContainer().GetBlockBlobReference(blobName);
        }
    }


}