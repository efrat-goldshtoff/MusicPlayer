using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Amazon.S3;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using serverProject.Core.Services;

namespace serverProject.Service
{
    public class AwsS3Service:IAwsS3Service
    {
        private readonly IAmazonS3 _s3Client;
        private readonly string _bucketName;
        private readonly string _region;

        public AwsS3Service(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _bucketName = configuration["AWS:BucketName"];
            _region = configuration["AWS:Region"];
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File is empty or null.");
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = $"{fileName}"; // You can organize with folders if needed

            var putObjectRequest = new PutObjectRequest
            {
                BucketName = _bucketName,
                Key = filePath,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,
                CannedACL = S3CannedACL.PublicRead // Make the file publicly accessible
            };

            await _s3Client.PutObjectAsync(putObjectRequest);

            return GetFileUrl(fileName); // Return the public URL
        }

        public async Task<bool> DeleteFileAsync(string fileUrl)
        {
            if (string.IsNullOrEmpty(fileUrl)) return false;

            var uri = new Uri(fileUrl);
            var key = uri.Segments[^1]; // Get the last segment (file name)

            var deleteObjectRequest = new DeleteObjectRequest
            {
                BucketName = _bucketName,
                Key = key
            };

            var response = await _s3Client.DeleteObjectAsync(deleteObjectRequest);

            // Return true if the deletion was successful
            return true; // או ניתן להחזיר response.HttpStatusCode == HttpStatusCode.NoContent כדי לבדוק את הסטטוס
        }


        //public async Task<bool> DeleteFileAsync(string fileUrl)
        //{
        //    if (string.IsNullOrEmpty(fileUrl)) return false;

        //    var uri = new Uri(fileUrl);
        //    var key = uri.Segments[^1]; // Get the last segment (file name)

        //    var deleteObjectRequest = new DeleteObjectRequest
        //    {
        //        BucketName = _bucketName,
        //        Key = key
        //    };

        //    var response = await _s3Client.DeleteObjectAsync(deleteObjectRequest);
        //    return response.DeleteMarker; // True if the object was deleted or already didn't exist
        //}

        public string GetFileUrl(string fileName)
        {
            // This URL format might vary slightly based on region and bucket configuration
            return $"https://{_bucketName}.s3.{_region}.amazonaws.com/{fileName}";
        }
    }
}
