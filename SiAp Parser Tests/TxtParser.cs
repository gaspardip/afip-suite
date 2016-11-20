﻿using System;
using System.Globalization;
using SiAp_Parser_Tests.Models;

namespace SiAp_Parser_Tests
{
    public class TxtParser
    {
        public TxtParser()
        {

        }

        public ComprobanteCompra ParseBuysVoucher(string line)
        {
            var c = new ComprobanteCompra();

            c.Fecha = DateTime.ParseExact(line.Substring(0, 8), "yyyyMMdd", CultureInfo.InvariantCulture);
            c.Tipo = Convert.ToInt16(line.Substring(8, 3));


            return c;
        } 
    }
}
