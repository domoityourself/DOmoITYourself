using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;
using BlogHomekit.Services.Configuration;


namespace BlogHomekit.Services
{
    public static class AzureStorageService
    {
        public static CloudBlobContainer GetBlobContainer()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(WebConfigParameter.StorageConnectionString);

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference(WebConfigParameter.BlobAzureContainerName);

            if (container.CreateIfNotExists())
            {
                container.SetPermissions(
                    new BlobContainerPermissions
                    {
                        PublicAccess = BlobContainerPublicAccessType.Container
                    });
                }
                return container;
            }

        public static void UploadImage(this CloudBlobContainer StorageContainer, string blobName, WebImage image)
        {
            CloudBlockBlob blob = StorageContainer.GetBlockBlobReference(blobName);
            blob.Properties.ContentType = "image/" + image.ImageFormat;

            using (var stream = new MemoryStream(image.GetBytes(), writable: false))
            {
                blob.UploadFromStream(stream);
            }
        }

        public static string GetBlobName(string folderPath, string filename)
        {
            return $"{folderPath}{filename}".Substring(1, folderPath.Length + filename.Length - 1);
        }

        public static void DeleteImage(this CloudBlobContainer storageContainer, string blobName)
        {
            var blockBlob = storageContainer.GetBlockBlobReference(blobName);
            blockBlob.DeleteAsync();
        }
    }
}

