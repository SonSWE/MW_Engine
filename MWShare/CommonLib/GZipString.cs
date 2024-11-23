using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public static class GZipString
    {
        private static readonly Encoding encoding = Encoding.UTF8;

        public static async Task CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = await src.ReadAsync(bytes, 0, bytes.Length)) != 0)
            {
                await dest.WriteAsync(bytes.AsMemory(0, cnt));
            }
        }

        public static async Task<byte[]> Zip(string str)
        {
            var bytes = encoding.GetBytes(str);

            using var msi = new MemoryStream(bytes);
            using var mso = new MemoryStream();
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
            {
                await CopyTo(msi, gs);
            }

            return mso.ToArray();
        }

        public static async Task ZipToFile(string str, string filePath)
        {
            var bytes = encoding.GetBytes(str);

            using var msi = new MemoryStream(bytes);
            using var fileStream = File.Create(filePath);
            using var gs = new GZipStream(fileStream, CompressionMode.Compress);
            await CopyTo(msi, gs);
        }


        public static async Task<string> Unzip(byte[] bytes)
        {
            using var msi = new MemoryStream(bytes);
            using var mso = new MemoryStream();
            using (var gs = new GZipStream(msi, CompressionMode.Decompress))
            {
                await CopyTo(gs, mso);
            }

            return encoding.GetString(mso.ToArray());
        }
    }
}
