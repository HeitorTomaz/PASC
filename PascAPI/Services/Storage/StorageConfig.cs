using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PASC.Services.Storage
{
    public class StorageConfig
    {
        public string AccountName { get; set; }
        public string AccountKey { get; set; }
        public string QueueName { get; set; }
        public string ImageContainer { get; set; }
        public string ThumbnailContainer { get; set; }
        public int UriDurationInMinutes { get; set; }
    }
}
