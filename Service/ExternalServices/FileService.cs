using Service.Abstraction.IExternalServices;
using Service.ExternalServices.FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.ExternalServices
{
    public class FileService : IFileService
    {
        public async Task<string> Save(string path, string mimeType, string content)
        {
            string fileExtension = MimeTypes.GetExtension(mimeType);
            string filePath = Path.Combine("wwwroot", Path.Combine(path, fileExtension));
            await File.WriteAllBytesAsync(filePath, Base64ToFile(content));

            return fileExtension;
        }

        public byte[] Base64ToFile(string content) => Convert.FromBase64String(content);

        public async Task<string> SaveImage(string path, string image)
        {
            string mimeType = Base64Utils.GetImageMimeTypeFromBase64(image);

            string fileExtension = await Save(path, mimeType, image);

            return $"{path}{fileExtension}";
        }

        public async Task<string> SavePdf(string path, string pdf)
        {
            string mimeType = Base64Utils.GetPdfMimeTypeFromBase64(pdf);
           
            string fileExtension = await Save(path, mimeType, pdf);

            return $"{path}{fileExtension}";
        }

        public async Task<string> SaveVideo(string path, string video)
        {
            string mimeType = Base64Utils.GetVideoMimeTypeFromBase64(video);
            
            string fileExtension = await Save(path, mimeType, video);

            return $"{path}{fileExtension}";
        }

        public async Task<string> SaveVoice(string path, string voice)
        {
            string mimeType = Base64Utils.GetVoiceMimeTypeFromBase64(voice);
            
            string fileExtension = await Save(path, mimeType, voice);

            return $"{path}{fileExtension}";
        }
    }
}
