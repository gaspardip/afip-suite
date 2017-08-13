using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelDataReader;

namespace SiAp_Parser.Extensions
{
    public static class IExcelDataReaderExtensions
    {
        public static double GetSafeDouble(this IExcelDataReader reader, int i)
        {
            double value;

            try
            {
                value = reader.GetDouble(i);
            }
            catch
            {
                value = 0;
            }

            if (value == double.MinValue || value == double.MaxValue)
                return 0;

            if (value < 0)
                return -value;

            return value;
        }

        // https://github.com/ExcelDataReader/ExcelDataReader#how-to-use
        public static string GetSafeString(this IExcelDataReader reader, int i)
        {
            var value = reader.GetValue(i);

            if (value == null)
                return null;

            var type = value.GetType();

            if (type == typeof(string))
                return (string)value;

            if (type == typeof(int))
                return ((int)value).ToString();

            if (type == typeof(double))
                return ((double)value).ToString();

            return string.Empty;
        }
    }
}
