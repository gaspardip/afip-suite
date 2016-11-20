using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiAp_Parser;
using SiAp_Parser.Enums;

namespace SiAp_Parser_Tests
{
    [TestClass]
    public class ParsingTests
    {
        const string TEST_LINE = "201601040010000100000000000000000081                8000000000030708700955SEXTA GENERACION SRL          000000000341220000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000PES00010000001 00000000000000000000000000000000000000000                              000000000000000";

        [TestMethod]
        public void CheckDateParsing()
        {
            var expectedDate = new DateTime(2016, 1, 4);
            var parser = new TxtParser();
            var voucher = parser.ParseBuysVoucher(TEST_LINE);
            Assert.AreEqual(expectedDate, voucher.Fecha);
        }

        [TestMethod]
        public void CheckVoucherTypeParsing()
        {
            var expectedType = ((int)TipoComprobante.FACTURAS_A).ToString("D3");
            var parser = new TxtParser();
            var voucher = parser.ParseBuysVoucher(TEST_LINE);
            Assert.AreEqual(expectedType, voucher.Tipo.ToString("D3"));
        }
    }
}
