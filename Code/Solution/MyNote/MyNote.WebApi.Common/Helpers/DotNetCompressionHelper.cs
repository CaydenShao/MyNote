using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace MyNote.WebApi.Common.Helpers
{
    public static class DotNetCompressionHelper
    {
        public static byte[] DeflateBytes(byte[] bytes)
        {
            if (bytes == null && bytes.Length == 0)
            {
                return null;
            }

            using (MemoryStream output = new MemoryStream())
            {
                using (DeflateStream compressor = new DeflateStream(output, CompressionMode.Compress))
                {
                    compressor.Write(bytes, 0, bytes.Length);
                }

                return output.ToArray();
            }
        }

        public static byte[] GZipBytes(byte[] bytes)
        {
            if (bytes == null && bytes.Length == 0)
            {
                return null;
            }

            using (MemoryStream output = new MemoryStream())
            {
                using (GZipStream compressor = new GZipStream(output, CompressionMode.Compress))
                {
                    compressor.Write(bytes, 0, bytes.Length);
                }

                return output.ToArray();
            }
        }
    }
}
