using Domain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Service.ExternalServices.FileHelpers
{
    public static class Base64Utils
    {
        private static string GetValue(string data)
        {
            if (FileUtility.VedioPrefixes.TryGetValue(data.ToUpper(), out string? value))
                return value;
            throw new Exception("");
        }
        public static string GetImageMimeTypeFromBase64(string base64String)
        {
            return GetValue(base64String.Substring(0, 5));
        }

        /// <summary>
        /// Problem
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static string GetVoiceMimeTypeFromBase64(string base64String)
        {
            return GetValue(base64String.Substring(0, 5)); //
        }
       
        /// <summary>
        /// Problem
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        public static string GetVideoMimeTypeFromBase64(string base64String)
        {
            return GetValue(base64String.Substring(0, 5));
        }
        public static string GetPdfMimeTypeFromBase64(string base64String)
        {
            return GetValue(base64String.Substring(0, 11));
        }
    }
}
