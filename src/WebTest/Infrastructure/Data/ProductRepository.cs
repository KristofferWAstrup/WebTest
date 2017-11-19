using Microsoft.WindowsAzure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using Microsoft.Azure; //Namespace for CloudConfigurationManager
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Infrastructure.Data.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace WebTest.Infrastructure.Data
{
    public class ProductRepository : IDisposable
    {

        public List<Product> GetAll(int size,int page)
        {
            var elements = GetAll();
            int rest = Math.Max((size * page)-elements.Count, 0);
            int index = Math.Min(size*page,elements.Count)-1;
            return elements.GetRange(index, rest);
        }

        public List<Product> GetAll()
        {
            var container = GetCloudBlobContainer("product");

            List<Product> products = new List<Product>();

            foreach (IListBlobItem item in container.ListBlobs(null, false))
            {
              
                CloudBlockBlob blob = (CloudBlockBlob)item;
                
                products.Add(GetProductFromCloudBlockBlob(blob));

            }

            return products;
        }

        public Product Get(Guid id)
        {
            var container = GetCloudBlobContainer("product");

            var blob = container.GetBlockBlobReference(id.ToString());

            return GetProductFromCloudBlockBlob(blob);

        }

        public void Add(Product product)
        {
            var container = GetCloudBlobContainer("product");

            CloudBlockBlob blockBlob = container.GetBlockBlobReference(product.Id.ToString());

            string json = JsonConvert.SerializeObject(product);

            blockBlob.UploadText(json,Encoding.UTF8);

        }

        private Product GetProductFromCloudBlockBlob(CloudBlockBlob blob)
        {
            string json = blob.DownloadText(Encoding.UTF8);

            var product = JsonConvert.DeserializeObject<Product>(json);

            return product;
        }

        private CloudBlobContainer GetCloudBlobContainer(CloudBlobClient cloudBlobClient,string containerName)
        {
            CloudBlobContainer container = cloudBlobClient.GetContainerReference(containerName);
            return container;
        }

        private CloudBlobContainer GetCloudBlobContainer(string containerName)
        {
            return GetCloudBlobContainer(GetCloudBlobClient(), containerName);
        }

        private CloudStorageAccount GetStorageAccount()
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("StorageConnectionString"));
            return storageAccount;
        }

        private CloudBlobClient GetCloudBlobClient()
        {
            return GetCloudBlobClient(GetStorageAccount());
        }

        private CloudBlobClient GetCloudBlobClient(CloudStorageAccount cloudStorageAccount)
        {
            return cloudStorageAccount.CreateCloudBlobClient();
        }

        public void Dispose()
        {
            
        }
    }
}