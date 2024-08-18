using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalServices.FileHelpers
{
    public static class Base64Utils
    {
        public static string GetImageMimeTypeFromBase64(string base64String)
        {
            var data = base64String.Substring(0, 5);
            return data.ToUpper() switch
            {
                "IVBOR" => "image/png",
                "/9J/4" => "image/jpeg",
                "R0LGO" => "image/gif",
                _ => throw new ArgumentException("Unsupported base64 image format"),
            };
        }
        public static string GetVoiceMimeTypeFromBase64(string base64String)
        {
            var data = base64String.Substring(0, 5);
            return data.ToUpper() switch
            {
                "IVBOR" => "image/png",
                "/9J/4" => "image/jpeg",
                "R0LGO" => "image/gif",
                _ => throw new ArgumentException("Unsupported base64 image format"),
            };
        }
        public static string GetVideoMimeTypeFromBase64(string base64String)
        {
            var data = base64String.Substring(0, 5);
            return data.ToUpper() switch
            {
                "IVBOR" => "image/png",
                "/9J/4" => "image/jpeg",
                "R0LGO" => "image/gif",
                _ => throw new ArgumentException("Unsupported base64 image format"),
            };
        }
        public static string GetPdfMimeTypeFromBase64(string base64String)
        {
            var data = base64String.Substring(0, 5);
            return data.ToUpper() switch
            {
                "IVBOR" => "image/png",
                "/9J/4" => "image/jpeg",
                "R0LGO" => "image/gif",
                _ => throw new ArgumentException("Unsupported base64 image format"),
            };
        }
    }
}
