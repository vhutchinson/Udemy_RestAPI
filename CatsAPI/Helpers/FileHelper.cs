using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CatsAPI.Helpers
{
    public static class FileHelper
    {
        public static async Task<string> UploadImage(IFormFile image)
        {
            // Get BobClient
            string connection = @"DefaultEndpointsProtocol=https;AccountName=catstorageaccount;AccountKey=WHaAnrsZ2EA38R4r/IHRRZZ4EvD8b3bjis5vQI1VnOT/66XOBqkbW33VpMaqh4BNcIv+OfdsXKlqev9Rnswwwg==;EndpointSuffix=core.windows.net";
            string containerName = "mycatssleeping";
            BlobContainerClient blobContainerClient = new BlobContainerClient(connection, containerName);
            BlobClient blobClient = blobContainerClient.GetBlobClient(image.FileName);

            // Upload image
            var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            await blobClient.UploadAsync(memoryStream);

            // Return image URL string
            return blobClient.Uri.AbsoluteUri;
        }
    }
}
