using Domain.Utilities;
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
            return FileUtility.ImagePrefixes[data.ToUpper()];
        }

        /// <summary>
        /// Problem
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static string GetVoiceMimeTypeFromBase64(string base64String)
        {
            var data = base64String.Substring(0, 5); //
            return FileUtility.VoicePrefixes[data.ToUpper()];
        }
       
        /// <summary>
        /// Problem
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static string GetVideoMimeTypeFromBase64(string base64String)
        {
            var data = base64String.Substring(0, 5); //
            return FileUtility.VedioPrefixes[data.ToUpper()];
        }
        public static string GetPdfMimeTypeFromBase64(string base64String)
        {
            var data = base64String.Substring(0, 11);
            return FileUtility.PdfPrefixes[data.ToUpper()];
        }
    }
}
