using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace API.Extensions
{
    public static class ConvertExtensions
    {
        public static string ConvertToBase64(this IFormFile? file)
        {
            string base64Output = ""; 
            
            if (file?.Length > 0)
            {
                using var stream = new MemoryStream();
                file.CopyTo(stream);
                byte[] fileBytes = stream.ToArray();
                base64Output = Convert.ToBase64String(fileBytes);
            }

            return base64Output;
        }
    }
}