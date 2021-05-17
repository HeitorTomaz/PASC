using Microsoft.Extensions.Options;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Services.Storage
{
    public class StorageHelper
    {
        
        private readonly CloudBlobContainer _container = null;
        private readonly StorageConfig _storageConfig = null;

        public StorageHelper(IOptions<StorageConfig> config)
        {
            _storageConfig = config.Value;
            var storageCredentials = new StorageCredentials(_storageConfig.AccountName, _storageConfig.AccountKey);
            var storageAccount = new CloudStorageAccount(storageCredentials, true);
            var blobClient = storageAccount.CreateCloudBlobClient();
            _container = blobClient.GetContainerReference(_storageConfig.ImageContainer);
        }

        public async Task UploadFileToStorage(Stream fileStream, string fileName)
        {
            var blockBlob = _container.GetBlockBlobReference(fileName);
            await blockBlob.UploadFromStreamAsync(fileStream);
        }

        public string GetTemporaryUri(string fileName)
        {
            var blockBlob = _container.GetBlockBlobReference(fileName);
            return blockBlob.Uri + blockBlob.GetSharedAccessSignature(
                new SharedAccessBlobPolicy(){
                    SharedAccessExpiryTime = DateTime.Now.AddMinutes(_storageConfig.UriDurationInMinutes),
                    Permissions = SharedAccessBlobPermissions.Read
                });
        }

        public bool IsImage(string nameFile)
        {
            string[] formats = new string[] { ".jpg", ".png", ".gif", ".jpeg" };
            return formats.Any(item => nameFile.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }
    }
}
