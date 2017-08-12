using ExcelDataReader;
using System.IO;

namespace SiAp_Parser.Extensions
{
    public static class FileStreamExtensions
    {
        public static IExcelDataReader GetExcelDataReader(this FileStream stream)
        {
            return
                Path.GetExtension(stream.Name) == ".xls" ?
                ExcelReaderFactory.CreateBinaryReader(stream) : ExcelReaderFactory.CreateOpenXmlReader(stream);
        }
    }
}
