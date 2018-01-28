using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SiAp_Parser.Extensions
{
    public static class StringExtensions
    {
        // http://stackoverflow.com/questions/2201595/c-sharp-simplest-way-to-remove-first-occurance-of-a-substring-from-another-str
        public static string RemoveFirst(this string source, string remove)
        {
            var index = source.IndexOf(remove, StringComparison.Ordinal);

            return index < 0
                ? source
                : source.Remove(index, remove.Length);
        }

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

        public static string DefaultEncodingToUTF8(this string str)
        {
            var bytes = Encoding.Default.GetBytes(str);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}
