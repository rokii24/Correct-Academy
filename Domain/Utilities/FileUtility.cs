using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilities
{
    public class FileUtility
    {
        public static readonly Dictionary<string, string> MimeTypeMappings =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                { JpegImage, ".jpg" },
                { PngImage, ".png" },
                { GifImage, ".gif" },
           
                { Pdf, ".pdf" },
                
                { Mp4Video, ".mp4" },
                { WebMVideo, ".webm" },
                { AviVideo, ".avi" },
                { MovVideo, ".mov" },
                { MpegVideo, ".mpg" },
                { OggVideo, ".ogv" },

                { Mp3Voice, ".mp3" },
                { WaveVoice, ".wav" },
                { OggVoice, ".oog" },
                { FlacVoice, ".flac" },
                { MidiVoice, ".mid" },
            };

        #region Image 
        public static readonly Dictionary<string, string> ImagePrefixes =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                { "/9J/4", FileUtility.JpegImage},
                { "IVBOR", FileUtility.PngImage },
                { "R0LGO", FileUtility.GifImage },
            };
        public const string JpegImage = "image/jpeg";
        public const string PngImage = "image/png";
        public const string GifImage = "image/gif";
        #endregion

        #region Vedio 
        public static readonly Dictionary<string, string> VedioPrefixes =
          new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
          {
                {"AAAAFGZ0eXBtcDQy", Mp4Video},
                {"AAAAFGZ0eXBxdCA", MovVideo},
                {"AAAAFGZ0eXBtcDQ", MpegVideo},
                {"AAABGZ0eXBhdml", AviVideo},
                {"GkXfo59ChoEB", WebMVideo},
                {"T2dnUw", OggVideo}
          };
        public const string Mp4Video = "video/mp4";
        public const string WebMVideo = "video/webm";
        public const string AviVideo = "video/x-msvideo";
        public const string MovVideo = "video/quicktime";
        public const string MpegVideo = "video/mpeg";
        public const string OggVideo = "video/ogg";
        #endregion

        #region Voice 
        public static readonly Dictionary<string, string> VoicePrefixes =
          new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
          {
                {"SUQzBAAAAA", Mp3Voice},
                {"T2dnUw", OggVoice},
                {"UklGR", WaveVoice},
                {"TVRoZ", MidiVoice},
                {"fLaC", FlacVoice},
          };
        public const string MidiVoice = "audio/midi";
        public const string FlacVoice = "audio/flac";
        public const string OggVoice = "audio/ogg";
        public const string WaveVoice = "audio/wav";
        public const string Mp3Voice = "audio/mpeg";
        #endregion

        #region Pdf 
        public static readonly Dictionary<string, string> PdfPrefixes =
            new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
            {
                {"JVBERi0xLjA", Pdf},
                {"JVBERi0xLjE", Pdf},
                {"JVBERi0xLjI", Pdf},
                {"JVBERi0xLjM", Pdf},
                {"JVBERi0xLjQ", Pdf},
                {"JVBERi0xLjU", Pdf},
                {"JVBERi0xLjY", Pdf},
                {"JVBERi0xLjc", Pdf},
            };
        public const string Pdf = "application/pdf";
        #endregion
    }
}
