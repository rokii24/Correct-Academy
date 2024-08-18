using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstraction.IExternalServices
{
    public interface IFileService
    {
        Task<string> Save(string path, string mimeType, string content);
        byte[] Base64ToFile(string content);
        Task<string> SaveVoice(string path, string voice);
        Task<string> SaveImage(string path, string image);
        Task<string> SaveVideo(string path, string video);
        Task<string> SavePdf(string path, string pdf);

    }
}
