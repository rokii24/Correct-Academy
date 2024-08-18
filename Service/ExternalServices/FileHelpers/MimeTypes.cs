using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalServices.FileHelpers
{
    public static class MimeTypes
    {
        private static readonly Dictionary<string, string> MimeTypeMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "image/jpeg", ".jpg" },
            { "image/png", ".png" },
            { "image/gif", ".gif" },
          
        };

        public static string GetExtension(string mimeType)
        {
            if (MimeTypeMappings.TryGetValue(mimeType, out string? extension))
            {
                return extension;
            }

            throw new ArgumentException($"Unsupported MIME type: {mimeType}");
        }
    }
}