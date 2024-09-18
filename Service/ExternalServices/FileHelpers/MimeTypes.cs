using Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ExternalServices.FileHelpers
{
    public static class MimeTypes
    {
        public static string GetExtension(string mimeType)
        {
            if (FileUtility.MimeTypeMappings
                    .TryGetValue(mimeType, out string? extension))
                return extension;
            throw new ArgumentException($"Unsupported MIME type: {mimeType}");
        }
    }
}