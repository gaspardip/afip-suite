using System.IO;
using System.Security.Cryptography;

namespace SiAp_Parser.Extensions
{
    public static class StringExtensions
    {
        // http://stackoverflow.com/questions/13014704/how-to-work-out-if-a-file-has-been-modified
        public static byte[] GetFileHash(this string fileName)
        {
            var sha1 = HashAlgorithm.Create();

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                return sha1.ComputeHash(stream);
        }

        public static bool FileHasBeenModified(this string path, byte[] oldHash)
        {
            return oldHash != path.GetFileHash();
        }
    }
}
