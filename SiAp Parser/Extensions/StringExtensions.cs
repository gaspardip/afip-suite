using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SiAp_Parser.Extensions
{
    public static class StringExtensions
    {
        // http://stackoverflow.com/questions/2201595/c-sharp-simplest-way-to-remove-first-occurance-of-a-substring-from-another-str
        public static string RemoveFirst(this string source, string remove)
        {
            int index = source.IndexOf(remove);
            return (index < 0)
                ? source
                : source.Remove(index, remove.Length);
        }

        // http://stackoverflow.com/questions/13014704/how-to-work-out-if-a-file-has-been-modified
        public static byte[] GetFileHash(this string fileName)
        {
            var sha1 = HashAlgorithm.Create();
            using (FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                return sha1.ComputeHash(stream);
        }

        public static bool FileHasBeenModified(this string path, byte[] oldHash)
        {
            return oldHash != path.GetFileHash();
        }

        public static string DefaultEncodingToUTF8(this string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
