using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace serverProject.Core.Services
{
    public interface IAwsS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<bool> DeleteFileAsync(string fileUrl);
        string GetFileUrl(string fileName);
    }
}
